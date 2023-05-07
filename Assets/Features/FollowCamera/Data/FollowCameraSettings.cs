using UnityEngine;

namespace Features.FollowCamera.Data
{
	[CreateAssetMenu(fileName = "CameraSettings", menuName = "StaticData/Camera/Create Follow Camera Settings", order = 52)]
	public class FollowCameraSettings : ScriptableObject
	{
		public float Height;
	}
}