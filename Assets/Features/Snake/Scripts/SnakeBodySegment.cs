using UnityEngine;

namespace Features.Snake.Scripts
{
	public class SnakeBodySegment : MonoBehaviour
	{
		[SerializeField] private RelativeJoint2D joint2D;
		public void AttachTo(Rigidbody2D attachTo)
		{
			joint2D.connectedBody = attachTo;
		}
	}
}