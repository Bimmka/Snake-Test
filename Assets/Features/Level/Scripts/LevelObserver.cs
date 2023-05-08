using Features.Bonuses.Scripts.Factory;
using Features.Cleanup;
using Features.Level.Data;
using Features.Signals.Scripts;
using Features.Snake.Scripts.Factory;
using Features.UI.Data;
using Features.UI.Scripts.Base;
using Features.UserInput.Scripts;
using UnityEngine.SceneManagement;
using Zenject;

namespace Features.Level.Scripts
{
	public class LevelObserver : ICleanUp
	{
		private readonly IUserInput userInput;
		private readonly SnakeSpawner snakeSpawner;
		private readonly BonusSpawner bonusSpawner;
		private readonly ICleanUpService cleanUpService;
		private readonly SignalBus signalBus;
		private readonly LevelSettings settings;
		private readonly IWindowsService windowsService;

		public bool CleanUped { get; private set; }

		public LevelObserver(SnakeSpawner snakeSpawner, BonusSpawner bonusSpawner,  IUserInput userInput,
			SignalBus signalBus, ICleanUpService cleanUpService, LevelSettings settings, IWindowsService windowsService)
		{
			this.windowsService = windowsService;
			this.settings = settings;
			this.signalBus = signalBus;
			this.cleanUpService = cleanUpService;
			this.bonusSpawner = bonusSpawner;
			this.snakeSpawner = snakeSpawner;
			this.userInput = userInput;
			signalBus.Subscribe<SnakeHitSignal>(Finish);
			signalBus.Subscribe<RestartGameSignal>(RestartLevel);
			cleanUpService.Register(this);
		}

		public void CleanUp()
		{
			CleanUped = true;
			signalBus.Unsubscribe<SnakeHitSignal>(Finish);
			signalBus.Unsubscribe<RestartGameSignal>(RestartLevel);
		}

		public void Start()
		{
			userInput.Initialize();
			for (int i = 0; i < settings.BonusSpawnPositions.Length; i++)
			{
				bonusSpawner.Spawn(settings.BonusSpawnPositions[i]);
			}

			snakeSpawner.Create();
			windowsService.CreateWindow(WindowType.HUD);
		}

		private void Finish()
		{
			signalBus.Fire(new FinishGameSignal());
			windowsService.CreateWindow(WindowType.GameEnd);
		}

		private void RestartLevel()
		{
			cleanUpService.CleanUp();
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}