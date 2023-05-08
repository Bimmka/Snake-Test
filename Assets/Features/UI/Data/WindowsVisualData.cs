using System;
using Features.UI.Scripts.Windows;
using UnityEngine;

namespace Features.UI.Data
{
	[CreateAssetMenu(fileName = "WindowsVisualData", menuName = "StaticData/UI/Create Windows Visual Data", order = 52)]
	public class WindowsVisualData : ScriptableObject
	{
		public VisualData[] VisualData;
		public Transform UIRootPrefab;
	}

	[Serializable]
	public struct VisualData
	{
		public BaseWindow Window;
		public WindowType Type;
	}
}