using System.Collections.Generic;
using Features.Cleanup;
using Features.Effects.Scripts.CustomParticles;
using Features.Signals.Scripts;
using UnityEngine;
using Zenject;

namespace Features.Effects.Scripts.EffectsPool
{
	public class EffectsService : ICleanUp
	{
		private readonly Queue<CustomParticleObserver> pool;
		private readonly List<CustomParticleObserver> usingPool;
		private readonly SignalBus signalBus;
		private readonly EffectsFactory factory;
		private readonly Transform effectSpawnParent;
		public bool CleanUped { get; private set; }

		public EffectsService(EffectsFactory factory, Transform effectSpawnParent, ICleanUpService cleanUpService, SignalBus signalBus)
		{
			this.effectSpawnParent = effectSpawnParent;
			this.factory = factory;
			this.signalBus = signalBus;
			pool = new Queue<CustomParticleObserver>(3);
			usingPool = new List<CustomParticleObserver>(3);
			cleanUpService.Register(this);
			signalBus.Subscribe<PickUpBonusSignal>(OnPickUpBonus);
		}

		public void CleanUp()
		{
			signalBus.Unsubscribe<PickUpBonusSignal>(OnPickUpBonus);
			for (int i = 0; i < usingPool.Count; i++)
			{
				usingPool[i].Stopped -= OnParticleStop;
			}
		}

		private void OnPickUpBonus(PickUpBonusSignal signal)
		{
			CustomParticleObserver particleObserver;
			particleObserver = pool.Count > 0 ? pool.Dequeue() : factory.Create(signal.PickedUpBonus.transform.position, effectSpawnParent);

			particleObserver.Stopped += OnParticleStop;
			particleObserver.Show(signal.PickedUpBonus.transform.position);
			usingPool.Add(particleObserver);
		}

		private void OnParticleStop(CustomParticleObserver particleObserver)
		{
			particleObserver.Stopped -= OnParticleStop;
			pool.Enqueue(particleObserver);
			usingPool.Remove(particleObserver);
		}
	}
}