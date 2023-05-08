using Features.Bonuses.Scripts.Elements;
using UnityEngine;

namespace Features.Bonuses.Scripts.Factory
{
	public class BonusSpawner
	{
		private readonly Transform spawnParent;
		private readonly BonusFactory factory;

		public BonusSpawner(Transform spawnParent, BonusFactory factory)
		{
			this.factory = factory;
			this.spawnParent = spawnParent;
		}

		public Bonus Spawn(Vector3 at) =>
			factory.Create(at, Quaternion.identity, spawnParent);
	}
}