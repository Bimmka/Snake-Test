using Features.Bonuses.Scripts;
using Features.Bonuses.Scripts.Elements;

namespace Features.Signals.Scripts
{
	public readonly struct PickUpBonusSignal
	{
		public readonly Bonus PickedUpBonus;

		public PickUpBonusSignal(Bonus pickedUpBonus)
		{
			PickedUpBonus = pickedUpBonus;
		}
	}
}