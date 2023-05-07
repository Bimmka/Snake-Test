using Features.FollowCamera.Scripts;
using Features.Level.Scripts;
using Features.Snake.Scripts.Factory;
using Features.Updater.Scripts;
using Features.UserInput.Scripts;
using UnityEngine;
using Zenject;

namespace Features.Bootstrapp.Scripts
{
	public class LevelInstaller : MonoInstaller
	{
		[SerializeField] private Transform snakeSpawnParent;
		[SerializeField] private SnakeFollowCamera followCamera;
		[SerializeField] private UpdatableObjectsContainer updatableObjectsContainer;

		public override void Start()
		{
			base.Start();
			Container.Resolve<LevelObserver>().Start();
		}

		public override void InstallBindings()
		{
			Container.Bind<LevelObserver>().To<LevelObserver>().FromNew().AsSingle().WithArguments(snakeSpawnParent);
			Container.BindInterfacesTo<PCUserInputService>().FromNew().AsSingle();
			Container.Bind<SnakeFactory>().To<SnakeFactory>().FromNew().AsSingle();
			Container.BindInterfacesAndSelfTo<SnakeFollowCamera>().FromComponentInNewPrefab(followCamera).AsSingle();
			Container.BindInterfacesTo<UpdatableObjectsContainer>().FromComponentInNewPrefab(updatableObjectsContainer).AsSingle();
		}
	}
}