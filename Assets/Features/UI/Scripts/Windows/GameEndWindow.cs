using Features.Signals.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Features.UI.Scripts.Windows
{
	public class GameEndWindow : BaseWindow
	{
		[SerializeField] private Button restartButton;
		private SignalBus signalBus;

		[Inject]
		public void Construct(SignalBus signalBus)
		{
			this.signalBus = signalBus;
		}

		public override void Initialize()
		{
			base.Initialize();
			restartButton.onClick.AddListener(RestartGame);
		}

		protected override void Cleanup()
		{
			base.Cleanup();
			restartButton.onClick.RemoveListener(RestartGame);
		}

		private void RestartGame() =>
			signalBus.Fire(new RestartGameSignal());
	}
}