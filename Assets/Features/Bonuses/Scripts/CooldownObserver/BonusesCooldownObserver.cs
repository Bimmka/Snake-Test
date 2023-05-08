using System.Collections.Generic;
using Features.Bonuses.Data;
using Features.Bonuses.Scripts.Elements;
using Features.Cleanup;
using Features.Signals.Scripts;
using Features.Updater.Scripts;
using Zenject;

namespace Features.Bonuses.Scripts.CooldownObserver
{
	public class BonusesCooldownObserver : ICleanUp, IUpdatable
	{
		private readonly SignalBus signalBus;
		private readonly List<BonusOnCooldown> bonusesOnCooldown;
		private readonly List<BonusOnCooldown> bonusesWithoutCooldown;
		private readonly BonusCooldownSettings settings;
		public bool CleanUped { get; private set; }

		public BonusesCooldownObserver(SignalBus signalBus, BonusCooldownSettings settings, IUpdatableObjectsContainer updatableObjectsContainer)
		{
			this.settings = settings;
			this.signalBus = signalBus;
			bonusesOnCooldown = new List<BonusOnCooldown>(3);
			bonusesWithoutCooldown = new List<BonusOnCooldown>(3);
			signalBus.Subscribe<PickUpBonusSignal>(OnBonusPickUp);
			updatableObjectsContainer.Register(this);
		}

		public void CleanUp()
		{
			CleanUped = true;
			signalBus.Unsubscribe<PickUpBonusSignal>(OnBonusPickUp);
		}

		public void Update(float deltaTime)
		{
			UpdateBonusCooldown(deltaTime);
			RemoveBonusesWithoutCooldown();
		}

		private void UpdateBonusCooldown(float deltaTime)
		{
			for (int i = 0; i < bonusesOnCooldown.Count; i++)
			{
				bonusesOnCooldown[i].AddTime(deltaTime);

				if (bonusesOnCooldown[i].CurrentCooldown >= settings.Cooldown)
				{
					bonusesOnCooldown[i].Bonus.Show();
					bonusesWithoutCooldown.Add(bonusesOnCooldown[i]);
				}
			}
		}

		private void RemoveBonusesWithoutCooldown()
		{
			for (int i = 0; i < bonusesWithoutCooldown.Count; i++)
			{
				bonusesOnCooldown.Remove(bonusesWithoutCooldown[i]);
			}

			bonusesWithoutCooldown.Clear();
		}

		private void OnBonusPickUp(PickUpBonusSignal signal)
		{
			signal.PickedUpBonus.Hide();
			bonusesOnCooldown.Add(new BonusOnCooldown(signal.PickedUpBonus));
		}

		private class BonusOnCooldown
		{
			public readonly Bonus Bonus;
			public float CurrentCooldown;

			public BonusOnCooldown(Bonus bonus)
			{
				Bonus = bonus;
				CurrentCooldown = 0;
			}

			public void AddTime(float deltaTime)
			{
				CurrentCooldown += deltaTime;
			}
		}
	}
}