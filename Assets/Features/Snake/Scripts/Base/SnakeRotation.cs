using Features.Snake.Data;
using UnityEngine;

namespace Features.Snake.Scripts.Base
{
	public class SnakeRotation
	{
		private readonly float rotationLerpCoefficient;

		public SnakeRotation(SnakeSettings settings)
		{
			rotationLerpCoefficient = settings.RotationLerpCoefficient;
		}

		public void Rotate(Rigidbody2D snakeBody, Vector2 moveDirection)
		{
			snakeBody.MoveRotation(Mathf.Lerp(snakeBody.rotation, ToRotationAngle(snakeBody, moveDirection), rotationLerpCoefficient));
			snakeBody.angularVelocity = 0;
		}

		public void RotateSegment(Rigidbody2D segmentBody, float rotation)
		{
			segmentBody.MoveRotation(Mathf.Lerp(segmentBody.rotation, rotation, rotationLerpCoefficient));
			segmentBody.angularVelocity = 0;
		}

		private float ToRotationAngle(Rigidbody2D snakeBody, Vector2 moveDirection) =>
			snakeBody.rotation + Vector2.SignedAngle(snakeBody.transform.right, moveDirection);
	}
}