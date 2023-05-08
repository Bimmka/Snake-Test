using UnityEngine;

namespace Features.Bonuses.Data
{
	[CreateAssetMenu(fileName = "BonusCooldownSettings", menuName = "StaticData/Bonus/Create Bonus Cooldown Settings", order = 52)]
	public class BonusCooldownSettings : ScriptableObject
	{
		public float Cooldown;
	}
}