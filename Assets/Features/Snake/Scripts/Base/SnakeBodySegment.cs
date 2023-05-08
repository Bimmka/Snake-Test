using UnityEngine;

namespace Features.Snake.Scripts.Base
{
	public class SnakeBodySegment : MonoBehaviour
	{
		[SerializeField] private Rigidbody2D segmentBody;
		public Rigidbody2D SegmentBody => segmentBody;
	}
}