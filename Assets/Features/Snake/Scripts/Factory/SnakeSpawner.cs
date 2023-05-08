using Features.Snake.Scripts.Base;
using UnityEngine;

namespace Features.Snake.Scripts.Factory
{
	public class SnakeSpawner
	{
		private readonly Transform spawnParent;
		private readonly SnakeFactory factory;

		public SnakeSpawner(Transform spawnParent, SnakeFactory factory)
		{
			this.factory = factory;
			this.spawnParent = spawnParent;
		}

		public SnakeHeadView Create()
		{
			return factory.CreateSnake(spawnParent);
		}
	}
}