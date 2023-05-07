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
			SceneManager.LoadScene("GameScene");
		}

		public override void InstallBindings()
		{
			SignalBusInstaller.Install(Container);
			Container.DeclareSignal<FinishGameSignal>();
		}
	}
}