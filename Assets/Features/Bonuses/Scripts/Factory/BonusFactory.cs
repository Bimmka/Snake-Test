using Features.Bonuses.Scripts.Elements;
using UnityEngine;
using Zenject;

namespace Features.Bonuses.Scripts.Factory
{
	public class BonusFactory
	{
		private readonly SignalBus signalBus;
		private readonly Bonus bonusPrefab;

		public BonusFactory(SignalBus signalBus, Bonus bonusPrefab)
		{
			this.bonusPrefab = bonusPrefab;
			this.signalBus = signalBus;
		}

		public Bonus Create(Vector3 at, Quaternion rotation, Transform parent)
		{
			Bonus bonus = Object.Instantiate(bonusPrefab, at, rotation, parent);
			bonus.Construct(signalBus);
			return bonus;
		}
	}
}