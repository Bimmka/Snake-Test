using System.Collections.Generic;
using Features.Cleanup;
using UnityEngine;
using Zenject;

namespace Features.Updater.Scripts
{
	public class UpdatableObjectsContainer : MonoBehaviour, IUpdatableObjectsContainer, ICleanUp
	{
		private List<IUpdatable> updatables = new List<IUpdatable>();

		public bool CleanUped { get; private set; }

		[Inject]
		public void Construct(List<IUpdatable> updatables, ICleanUpService cleanUpService)
		{
			this.updatables = updatables;
			cleanUpService.Register(this);
		}

		public void CleanUp()
		{
			CleanUped = true;
			updatables.Clear();
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