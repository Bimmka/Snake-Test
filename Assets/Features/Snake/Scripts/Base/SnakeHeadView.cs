using System;
using Features.Bonuses.Scripts.Elements;
using Features.Obstacles.Scripts;
using UnityEngine;

namespace Features.Snake.Scripts.Base
{
	public class SnakeHeadView : MonoBehaviour
	{
		[SerializeField] private Animator viewAnimator;
		[SerializeField] private Rigidbody2D snakeBody;

		private readonly int EatHash = Animator.StringToHash("Eat");

		public Rigidbody2D SnakeBody => snakeBody;
		public event Action ObstacleHit;
		public event Action<Bonus> BonusHit;
		public event Action SegmentHit;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetComponent(out Bonus bonus))
			{
				viewAnimator.SetTrigger(EatHash);
				BonusHit?.Invoke(bonus);
			}
			else if (other.TryGetComponent(out Obstacle obstacle))
				ObstacleHit?.Invoke();
			else if (other.TryGetComponent(out SnakeBodySegment segment))
				SegmentHit?.Invoke();
		}
	}
}