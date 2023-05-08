using System.Collections.Generic;
using UnityEngine;

namespace Features.Snake.Scripts.Base
{
	public class SnakePath
	{
		private readonly Rigidbody2D headBody;
		private readonly Dictionary<int,Queue<PathMarker>> markers;
		private readonly int markersForElement;
		private readonly float markerSaveInterval;

		private float currentSaveInterval;

		public SnakePath(Rigidbody2D headBody, int markersForElement, float markerSaveInterval)
		{
			this.markerSaveInterval = markerSaveInterval;
			this.markersForElement = markersForElement;
			this.headBody = headBody;
			markers = new Dictionary<int,Queue<PathMarker>>(10);
			markers.Add(0, new Queue<PathMarker>(markersForElement));
			currentSaveInterval = markerSaveInterval;
		}

		public void Update(IReadOnlyList<SnakeBodySegment> segments, float deltaTime)
		{
			currentSaveInterval += deltaTime;
			if (currentSaveInterval < markerSaveInterval)
				return;

			currentSaveInterval %= markerSaveInterval;

			foreach (KeyValuePair<int,Queue<PathMarker>> marker in markers)
			{
				if (marker.Value.Count >= markersForElement)
					marker.Value.Dequeue();
			}

			markers[0].Enqueue(new PathMarker(headBody.transform.position, headBody.rotation));

			for (int i = 0; i < segments.Count; i++)
			{
				if (markers.ContainsKey(i + 1) == false)
					markers.Add(i+1, new Queue<PathMarker>(markersForElement));
				markers[i+1].Enqueue(new PathMarker(segments[i].transform.position, segments[i].SegmentBody.rotation));
			}
		}

		public PathMarker Marker(int index)
		{
			int currentIndex = 0;
			if (markers.ContainsKey(index) == false)
				return default;

			PathMarker marker = default;
			foreach (PathMarker pathMarker in markers[index])
			{
				if (currentIndex >= markersForElement - 1)
				{
					marker =  pathMarker;
					break;
				}

				currentIndex++;
			}

			return marker;
		}

		public PathMarker LatestMarker(int index)
		{
			if (markers.ContainsKey(index) == false)
				return default;

			return markers[index].Peek();
		}
	}

	public readonly struct PathMarker
	{
		public readonly Vector3 Position;
		public readonly float Rotation;

		public PathMarker(Vector3 position, float rotation)
		{
			Position = position;
			Rotation = rotation;
		}
	}
}