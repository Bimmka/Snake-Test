using UnityEngine;

namespace Features.UserInput.Scripts
{
	public interface IUserInput
	{
		Vector2 CursorPosition { get; }
		void Initialize();
	}
}