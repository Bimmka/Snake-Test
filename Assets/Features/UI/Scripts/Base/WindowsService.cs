using Features.UI.Data;
using Features.UI.Scripts.Windows;

namespace Features.UI.Scripts.Base
{
	public class WindowsService : IWindowsService
	{
		private readonly IUIFactory uiFactory;

		public WindowsService(IUIFactory uiFactory)
		{
			this.uiFactory = uiFactory;
		}

		public BaseWindow CreateWindow(WindowType type)
		{
			if (uiFactory.UIRoot == null)
				uiFactory.CreateRoot();

			BaseWindow window = uiFactory.Create(type);
			window.Show();
			return window;
		}
	}
}