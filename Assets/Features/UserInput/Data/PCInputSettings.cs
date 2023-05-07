using UnityEngine;

namespace Features.UserInput.Data
{
	[CreateAssetMenu(fileName = "PCInputSettings", menuName = "StaticData/Input/Create PC Input Settings", order = 52)]
	public class PCInputSettings : ScriptableObject
	{
		public LayerMask CheckMask;
	}
}