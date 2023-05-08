using Features.GameScore.Scripts;
using TMPro;
using UnityEngine;
using Zenject;

namespace Features.UI.Scripts.Windows
{
	public class HUD : BaseWindow
	{
		[SerializeField] private TMP_Text scoreText;

		private GameScoreObserver gameScoreObserver;

		[Inject]
		public void Construct(GameScoreObserver gameScoreObserver)
		{
			this.gameScoreObserver = gameScoreObserver;
			this.gameScoreObserver.Changed += DisplayScore;
		}

		public override void Initialize()
		{
			DisplayScore(gameScoreObserver.CurrentScore);
			base.Initialize();
		}

		protected override void Cleanup()
		{
			base.Cleanup();
			gameScoreObserver.Changed -= DisplayScore;
		}

		private void DisplayScore(int count)
		{
			scoreText.text = count.ToString();
		}
	}
}