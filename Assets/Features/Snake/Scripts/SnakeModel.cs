using Features.FollowCamera.Scripts;
using Features.Updater.Scripts;
using Features.UserInput.Scripts;
using UnityEngine;

namespace Features.Snake.Scripts
{
	public class SnakeModel : IUpdatable
	{
		private readonly SnakeMove move;
		private readonly SnakeRotation rotation;
		private readonly IUserInput userInput;
		private readonly SnakeFollowCamera followCamera;
		private readonly Rigidbody2D snakeBody;

		public SnakeModel(Rigidbody2D snakeBody, SnakeMove move, SnakeRotation rotation, IUserInput userInput, SnakeFollowCamera followCamera)
		{
			this.snakeBody = snakeBody;
			this.followCamera = followCamera;
			this.userInput = userInput;
			this.rotation = rotation;
			this.move = move;
		}

		public void Update(float deltaTime)
		{
			move.Move(deltaTime);
			rotation.Rotate(userInput.CursorPosition);
			followCamera.ChangePosition(snakeBody.position);
		}
	}
}