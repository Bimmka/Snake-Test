using Features.Constants.Scripts;
using Features.Signals.Scripts;
using UnityEngine.SceneManagement;
using Zenject;

namespace Features.Bootstrapp.Scripts
{
	public class ProjectInstaller : MonoInstaller
	{
		public override void Start()
		{
			base.Start();
			SceneManager.LoadScene(GameConstants.GameSceneName);
		}

		public override void InstallBindings()
		{
			SignalBusInstaller.Install(Container);
			Container.DeclareSignal<FinishGameSignal>();
			Container.DeclareSignal<PickUpBonusSignal>();
			Container.DeclareSignal<SnakeHitSignal>();
			Container.DeclareSignal<RestartGameSignal>();
		}
	}
}