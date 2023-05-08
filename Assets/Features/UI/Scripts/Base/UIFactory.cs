using System.Linq;
using Features.UI.Data;
using Features.UI.Scripts.Windows;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Features.UI.Scripts.Base
{
	public class UIFactory : IUIFactory
	{
		private readonly WindowsVisualData visualData;
		private readonly DiContainer container;

		public Transform UIRoot { get; private set; }

		public UIFactory(WindowsVisualData visualData, DiContainer container)
		{
			this.container = container;
			this.visualData = visualData;
		}

		public Transform CreateRoot()
		{
			if (UIRoot == null)
				UIRoot = Object.Instantiate(visualData.UIRootPrefab);

			return UIRoot;
		}

		public BaseWindow Create(WindowType type)
		{
			BaseWindow windowPrefab = visualData.VisualData.FirstOrDefault(x => x.Type == type).Window;
			if (windowPrefab == null)
				return null;

			BaseWindow spawnedWindow = container.InstantiatePrefab(windowPrefab, UIRoot).GetComponent<BaseWindow>();
			spawnedWindow.Initialize();
			return spawnedWindow;
		}
	}
}