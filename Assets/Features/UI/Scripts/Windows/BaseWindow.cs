using System;
using UnityEngine;

namespace Features.UI.Scripts.Windows
{
	public class BaseWindow : MonoBehaviour
	{
		private void OnDestroy()
		{
			Cleanup();
		}

		public virtual void Initialize(){}

		public virtual void Show() { }

		public virtual void Hide() { }
		protected virtual void Cleanup() { }
	}
}