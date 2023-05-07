using Features.Snake.Data;
using UnityEngine;

namespace Features.Snake.Scripts
{
	public class SnakeMove
	{
		private readonly Rigidbody2D snakeBody;
		private readonly float moveSpeed;

		public SnakeMove(Rigidbody2D snakeBody, SnakeSettings settings)
		{
			this.snakeBody = snakeBody;
			moveSpeed = settings.MoveSpeed;
		}

		public void Move(float deltaTime)
		{
			snakeBody.MovePosition(snakeBody.position + new Vector2(snakeBody.transform.right.x, snakeBody.transform.right.y) * moveSpeed * deltaTime);
			snakeBody.velocity = Vector2.zero;
		}
	}
}