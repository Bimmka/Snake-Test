using Features.Effects.Scripts.CustomParticles;
using UnityEngine;

namespace Features.Effects.Scripts.EffectsPool
{
	public class EffectsFactory
	{
		private readonly CustomParticleObserver particlePrefab;

		public EffectsFactory(CustomParticleObserver particlePrefab)
		{
			this.particlePrefab = particlePrefab;
		}

		public CustomParticleObserver Create(Vector3 at, Transform spawnParent) =>
			Object.Instantiate(particlePrefab, at, particlePrefab.transform.rotation, spawnParent);
	}
}