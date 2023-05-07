using Features.Signals.Scripts;
using Features.Snake.Scripts.Factory;
using Features.UserInput.Scripts;
using UnityEngine;
using Zenject;

namespace Features.Level.Scripts
{
	public class LevelObserver
	{
		private readonly SnakeFactory snakeFactory;
		private readonly Transform snakeStartPoint;
		private readonly IUserInput userInput;

		public LevelObserver(SnakeFactory snakeFactory, Transform snakeStartPoint, IUserInput userInput, SignalBus signalBus)
		{
			this.userInput = userInput;
			this.snakeStartPoint = snakeStartPoint;
			this.snakeFactory = snakeFactory;
			signalBus.Subscribe<FinishGameSignal>(Finish);
		}

		public void Start()
		{
			userInput.Initialize();
			snakeFactory.CreateSnake(snakeStartPoint);
		}

		public void Finish()
		{
			
		}
	}
}