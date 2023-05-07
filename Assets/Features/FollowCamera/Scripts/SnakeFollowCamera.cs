using Features.FollowCamera.Data;
using UnityEngine;
using Zenject;

namespace Features.FollowCamera.Scripts
{
	public class SnakeFollowCamera : MonoBehaviour
	{
		[SerializeField] private Camera followCamera;

		private FollowCameraSettings settings;

		public Camera FollowCamera => followCamera;

		[Inject]
		public void Construct(FollowCameraSettings settings)
		{
			this.settings = settings;
		}

		public void ChangePosition(Vector3 snakeHeadPosition)
		{
			transform.position = snakeHeadPosition + Vector3.forward * settings.Height;
		}
	}
}