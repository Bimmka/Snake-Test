using System;
using Features.Cleanup;
using Features.Signals.Scripts;
using Zenject;

namespace Features.GameScore.Scripts
{
	public class GameScoreObserver : ICleanUp
	{
		private readonly SignalBus signalBus;
		public int CurrentScore { get; private set; }
		public bool CleanUped { get; private set; }

		public event Action<int> Changed;

		public GameScoreObserver(SignalBus signalBus, ICleanUpService cleanUpService)
		{
			this.signalBus = signalBus;
			signalBus.Subscribe<PickUpBonusSignal>(OnBonusPickUp);
			cleanUpService.Register(this);
		}

		public void CleanUp()
		{
			CleanUped = true;
			signalBus.Unsubscribe<PickUpBonusSignal>(OnBonusPickUp);
		}

		private void OnBonusPickUp()
		{
			CurrentScore++;
			Changed?.Invoke(CurrentScore);
		}
	}
}