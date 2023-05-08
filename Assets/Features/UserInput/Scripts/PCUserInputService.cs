using Features.FollowCamera.Scripts;
using Features.Updater.Scripts;
using UnityEngine;

namespace Features.UserInput.Scripts
{
	public class PCUserInputService : IUserInput, IUpdatable
	{
		private readonly Camera followCamera;
		private Plane raycastPlane;
		public Vector2 CursorPosition { get; private set; }

		public PCUserInputService(SnakeFollowCamera followCamera)
		{
			this.followCamera = followCamera.FollowCamera;
		}

		public void Initialize()
		{
			raycastPlane = new Plane(Vector3.forward, 0);
		}

		public void Update(float deltaTime)
		{
			float distance;
			Ray ray = followCamera.ScreenPointToRay(Input.mousePosition);
			if (raycastPlane.Raycast(ray, out distance)) 
				CursorPosition = ray.GetPoint(distance);
		}
	}
}