using Features.Snake.Scripts;
using UnityEngine;

namespace Features.Snake.Data
{
	[CreateAssetMenu(fileName = "SnakeSettings", menuName = "StaticData/Snake/Create Snake Settings", order = 52)]
	public class SnakeSettings : ScriptableObject
	{
		public float RotationLerpCoefficient;
		public float MoveSpeed;
		public SnakeHeadView SnakeHead;
		public SnakeBodySegment SnakeBodySegment;
	}
}