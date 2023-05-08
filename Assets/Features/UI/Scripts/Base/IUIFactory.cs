using Features.UI.Data;
using Features.UI.Scripts.Windows;
using UnityEngine;

namespace Features.UI.Scripts.Base
{
	public interface IUIFactory
	{
		Transform CreateRoot();
		BaseWindow Create(WindowType type);
		Transform UIRoot { get; }
	}
}