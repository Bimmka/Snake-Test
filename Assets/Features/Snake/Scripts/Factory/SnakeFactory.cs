using Features.FollowCamera.Scripts;
using Features.Snake.Data;
using Features.Updater.Scripts;
using Features.UserInput.Scripts;
using UnityEngine;

namespace Features.Snake.Scripts.Factory
{
	public class SnakeFactory
	{
		private readonly SnakeSettings snakeSettings;
		private readonly IUpdatableObjectsContainer updatableObjectsContainer;
		private readonly IUserInput userInput;
		private readonly SnakeFollowCamera snakeFollowCamera;

		public SnakeFactory(SnakeSettings snakeSettings, IUpdatableObjectsContainer updatableObjectsContainer, IUserInput userInput, 
			SnakeFollowCamera snakeFollowCamera)
		{
			this.snakeFollowCamera = snakeFollowCamera;
			this.userInput = userInput;
			this.updatableObjectsContainer = updatableObjectsContainer;
			this.snakeSettings = snakeSettings;
		}

		public SnakeHeadView CreateSnake(Transform at)
		{
			SnakeHeadView view = Object.Instantiate(snakeSettings.SnakeHead, at);
			SnakeMove move = new SnakeMove(view.SnakeBody, snakeSettings);
			SnakeRotation rotation = new SnakeRotation(view.SnakeBody, snakeSettings);
			SnakeModel model = new SnakeModel(view.SnakeBody, move, rotation, userInput, snakeFollowCamera);
			updatableObjectsContainer.Register(model);
			return view;
		}

		public SnakeBodySegment CreateSnakeSegment(Rigidbody2D attachTo, Vector3 position, Quaternion rotation, Transform parent)
		{
			SnakeBodySegment segment = Object.Instantiate(snakeSettings.SnakeBodySegment, position, rotation, parent);
			segment.AttachTo(attachTo);
			return segment;
		}
	}
}