using Features.Snake.Data;
using UnityEngine;

namespace Features.Snake.Scripts
{
	public class SnakeRotation
	{
		private readonly Rigidbody2D snakeBody;
		private readonly float rotationLerpCoefficient;

		public SnakeRotation(Rigidbody2D snakeBody, SnakeSettings settings)
		{
			this.snakeBody = snakeBody;
			rotationLerpCoefficient = settings.RotationLerpCoefficient;
		}

		public void Rotate(Vector2 moveDirection)
		{
			snakeBody.MoveRotation(Mathf.Lerp(snakeBody.rotation, ToRotationAngle(moveDirection), rotationLerpCoefficient));
			snakeBody.angularVelocity = 0;
		}

		private float ToRotationAngle(Vector2 moveDirection) =>
			snakeBody.rotation + Vector2.SignedAngle(snakeBody.transform.right, moveDirection);
	}
}