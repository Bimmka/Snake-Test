using Features.Snake.Scripts;
using Features.Snake.Scripts.Base;
using UnityEngine;

namespace Features.Snake.Data
{
	[CreateAssetMenu(fileName = "SnakeSettings", menuName = "StaticData/Snake/Create Snake Settings", order = 52)]
	public class SnakeSettings : ScriptableObject
	{
		public float RotationLerpCoefficient;
		public float MoveSpeed;
		public float SegmentMoveSpeed;
		public int MarkersForOneElement;
		public float MarkerSaveInterval;
		public SnakeHeadView SnakeHead;
		public SnakeBodySegment SnakeBodySegment;
	}
}