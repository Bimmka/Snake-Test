using Features.Signals.Scripts;
using UnityEngine;
using Zenject;

namespace Features.Bonuses.Scripts.Elements
{
	public class Bonus : MonoBehaviour
	{
		[SerializeField] private Sprite defaultView;
		[SerializeField] private Sprite disabledView;
		[SerializeField] private SpriteRenderer bonusRenderer;
		[SerializeField] private BoxCollider2D bonusCollider;
		private SignalBus signalBus;

		public void Construct(SignalBus signalBus)
		{
			this.signalBus = signalBus;
		}

		public void PickUp()
		{
			signalBus.Fire(new PickUpBonusSignal(this));
		}

		public void Show()
		{
			bonusRenderer.sprite = defaultView;
			bonusCollider.enabled = true;
		}

		public void Hide()
		{
			bonusRenderer.sprite = disabledView;
			bonusCollider.enabled = false;
		}
	}
}