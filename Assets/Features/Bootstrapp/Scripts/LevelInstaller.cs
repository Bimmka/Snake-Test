using Features.Bonuses.Scripts.CooldownObserver;
using Features.Bonuses.Scripts.Elements;
using Features.Bonuses.Scripts.Factory;
using Features.Cleanup;
using Features.Effects.Scripts.CustomParticles;
using Features.Effects.Scripts.EffectsPool;
using Features.FollowCamera.Scripts;
using Features.GameScore.Scripts;
using Features.Level.Scripts;
using Features.Snake.Scripts.Factory;
using Features.UI.Scripts.Base;
using Features.Updater.Scripts;
using Features.UserInput.Scripts;
using UnityEngine;
using Zenject;

namespace Features.Bootstrapp.Scripts
{
	public class LevelInstaller : MonoInstaller
	{
		[SerializeField] private Transform snakeSpawnParent;
		[SerializeField] private Transform bonusSpawnParent;
		[SerializeField] private SnakeFollowCamera followCamera;
		[SerializeField] private UpdatableObjectsContainer updatableObjectsContainer;
		[SerializeField] private Bonus bonusPrefab;
		[SerializeField] private Transform effectsParent;
		[SerializeField] private CustomParticleObserver particleObserverPrefab;

		public override void Start()
		{
			base.Start();
			Container.Resolve<LevelObserver>().Start();
			Container.Resolve<BonusesCooldownObserver>();
			Container.Resolve<EffectsService>();
		}

		public override void InstallBindings()
		{
			BinsLevelObserver();
			BindSnakeElements();
			BindUpdatableContainer();
			BindBonusElements();
			BindCleanupService();
			BindEffectElements();
			BindUIElements();
			BindGameScore();
		}

		private void BinsLevelObserver()
		{
			Container.Bind<LevelObserver>().To<LevelObserver>().FromNew().AsSingle();
		}

		private void BindSnakeElements()
		{
			Container.BindInterfacesTo<PCUserInputService>().FromNew().AsSingle();
			Container.Bind<SnakeFactory>().To<SnakeFactory>().FromNew().AsSingle();
			Container.Bind<SnakeSpawner>().To<SnakeSpawner>().FromNew().AsSingle().WithArguments(snakeSpawnParent);
			Container.BindInterfacesAndSelfTo<SnakeFollowCamera>().FromComponentInNewPrefab(followCamera).AsSingle();
		}

		private void BindUpdatableContainer() =>
			Container.BindInterfacesTo<UpdatableObjectsContainer>().FromComponentInNewPrefab(updatableObjectsContainer).AsSingle();

		private void BindBonusElements()
		{
			Container.Bind<BonusFactory>().To<BonusFactory>().FromNew().AsSingle().WithArguments(bonusPrefab);
			Container.Bind<BonusSpawner>().To<BonusSpawner>().FromNew().AsSingle().WithArguments(bonusSpawnParent);
			Container.Bind<BonusesCooldownObserver>().To<BonusesCooldownObserver>().FromNew().AsSingle();
		}

		private void BindCleanupService() =>
			Container.BindInterfacesTo<CleanUpService>().FromNew().AsSingle();

		private void BindEffectElements()
		{
			Container.Bind<EffectsFactory>().To<EffectsFactory>().FromNew().AsSingle().WithArguments(particleObserverPrefab);
			Container.Bind<EffectsService>().To<EffectsService>().FromNew().AsSingle().WithArguments(effectsParent);
		}

		private void BindUIElements()
		{
			Container.BindInterfacesTo<WindowsService>().FromNew().AsSingle();
			Container.BindInterfacesTo<UIFactory>().FromNew().AsSingle();
		}

		private void BindGameScore() =>
			Container.BindInterfacesAndSelfTo<GameScoreObserver>().FromNew().AsSingle();
	}
}