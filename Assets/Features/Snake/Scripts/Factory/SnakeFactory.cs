using Features.Cleanup;
using Features.FollowCamera.Scripts;
using Features.Snake.Data;
using Features.Snake.Scripts.Base;
using Features.Updater.Scripts;
using Features.UserInput.Scripts;
using UnityEngine;
using Zenject;

namespace Features.Snake.Scripts.Factory
{
	public class SnakeFactory
	{
		private readonly SnakeSettings snakeSettings;
		private readonly IUpdatableObjectsContainer updatableObjectsContainer;
		private readonly IUserInput userInput;
		private readonly SnakeFollowCamera snakeFollowCamera;
		private readonly SignalBus signalBus;
		private readonly ICleanUpService cleanUpService;

		public SnakeFactory(SnakeSettings snakeSettings, IUpdatableObjectsContainer updatableObjectsContainer, IUserInput userInput, 
			SnakeFollowCamera snakeFollowCamera, SignalBus signalBus, ICleanUpService cleanUpService)
		{
			this.cleanUpService = cleanUpService;
			this.signalBus = signalBus;
			this.snakeFollowCamera = snakeFollowCamera;
			this.userInput = userInput;
			this.updatableObjectsContainer = updatableObjectsContainer;
			this.snakeSettings = snakeSettings;
		}

		public SnakeHeadView CreateSnake(Transform at)
		{
			SnakeHeadView view = Object.Instantiate(snakeSettings.SnakeHead, at);
			SnakeMove move = new SnakeMove(snakeSettings);
			SnakeRotation rotation = new SnakeRotation(snakeSettings);
			SnakePath path = new SnakePath(view.SnakeBody, snakeSettings.MarkersForOneElement, snakeSettings.MarkerSaveInterval);
			SnakeSegmentController segmentController = new SnakeSegmentController(this, at, move, rotation, path);
			SnakeModel model = new SnakeModel(view, move, rotation, userInput, snakeFollowCamera,segmentController,signalBus, path, cleanUpService);
			updatableObjectsContainer.Register(model);
			return view;
		}

		public SnakeBodySegment CreateSnakeSegment(Vector3 position, float rotation, Transform parent)
		{
			SnakeBodySegment segment = Object.Instantiate(snakeSettings.SnakeBodySegment, parent);
			segment.transform.position = position;
			segment.SegmentBody.rotation = rotation;
			segment.gameObject.SetActive(true);
			return segment;
		}
	}
}