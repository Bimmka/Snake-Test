using Features.UI.Data;
using Features.UI.Scripts.Windows;

namespace Features.UI.Scripts.Base
{
	public interface IWindowsService
	{
		BaseWindow CreateWindow(WindowType type);
	}
}