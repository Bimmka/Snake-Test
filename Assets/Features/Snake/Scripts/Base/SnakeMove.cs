using Features.Snake.Data;
using UnityEngine;

namespace Features.Snake.Scripts.Base
{
	public class SnakeMove
	{
		private readonly float moveSpeed;
		private readonly float segmentMoveSpeed;

		public SnakeMove(SnakeSettings settings)
		{
			moveSpeed = settings.MoveSpeed;
			segmentMoveSpeed = settings.SegmentMoveSpeed;
		}

		public void Move(float deltaTime, Rigidbody2D snakeBody)
		{
			snakeBody.MovePosition(snakeBody.position + new Vector2(snakeBody.transform.right.x, snakeBody.transform.right.y) * moveSpeed * deltaTime);
			snakeBody.velocity = Vector2.zero;
		}

		public void MoveSegment(float deltaTime, Rigidbody2D segmentBody, Vector3 at)
		{
			segmentBody.MovePosition(Vector2.Lerp(segmentBody.position, at,  (segmentMoveSpeed * deltaTime)));
			segmentBody.velocity = Vector2.zero;
		}
	}
}