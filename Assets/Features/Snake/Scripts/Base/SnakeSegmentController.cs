using System.Collections.Generic;
using Features.Snake.Scripts.Factory;
using UnityEngine;

namespace Features.Snake.Scripts.Base
{
	public class SnakeSegmentController
	{
		private readonly List<SnakeBodySegment> segments;
		private readonly SnakeFactory factory;
		private readonly SnakeMove move;
		private readonly SnakeRotation rotation;
		private readonly Transform spawnParent;
		private readonly SnakePath path;

		public IReadOnlyList<SnakeBodySegment> Segments => segments;

		public SnakeSegmentController(SnakeFactory factory, Transform spawnParent, SnakeMove move,
			SnakeRotation rotation, SnakePath path)
		{
			this.path = path;
			this.rotation = rotation;
			this.move = move;
			this.spawnParent = spawnParent;
			this.factory = factory;
			segments = new List<SnakeBodySegment>(10);
		}

		public void Grow()
		{
			PathMarker marker = path.LatestMarker(segments.Count);
			SnakeBodySegment segment = factory.CreateSnakeSegment(marker.Position, marker.Rotation, spawnParent);
			segments.Add(segment);
		}

		public void MoveSegments(float deltaTime)
		{
			if (segments.Count == 0)
				return;

			for (int i = 0; i < segments.Count; i++)
			{
				PathMarker marker = path.Marker(i);
				move.MoveSegment(deltaTime, segments[i].SegmentBody, marker.Position);
				rotation.RotateSegment(segments[i].SegmentBody, marker.Rotation);
				segments[i].SegmentBody.rotation = marker.Rotation;
			}
		}
	}
}