using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Features.Updater.Scripts
{
	public class UpdatableObjectsContainer : MonoBehaviour, IUpdatableObjectsContainer
	{
		private List<IUpdatable> updatables = new List<IUpdatable>();

		[Inject]
		public void Construct(List<IUpdatable> updatables)
		{
			this.updatables = updatables;
		}

		public void Register(IUpdatable updatable)
		{
			updatables.Add(updatable);
		}

		public void Remove(IUpdatable updatable)
		{
			updatables.Remove(updatable);
		}

		private void Update()
		{
			float deltaTime = Time.deltaTime;
			for (int i = 0; i < updatables.Count; i++)
			{
				updatables[i].Update(deltaTime);
			}
		}
	}
}