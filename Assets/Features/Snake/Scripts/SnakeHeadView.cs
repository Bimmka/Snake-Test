using UnityEngine;

namespace Features.Snake.Scripts
{
	public class SnakeHeadView : MonoBehaviour
	{
		[SerializeField] private Rigidbody2D snakeBody;

		public Rigidbody2D SnakeBody => snakeBody;
	}
}