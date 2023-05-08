using Features.Bonuses.Scripts.Elements;
using Features.Cleanup;
using Features.FollowCamera.Scripts;
using Features.Signals.Scripts;
using Features.Updater.Scripts;
using Features.UserInput.Scripts;
using Zenject;

namespace Features.Snake.Scripts.Base
{
	public class SnakeModel : IUpdatable, ICleanUp
	{
		private readonly SnakeMove move;
		private readonly SnakeRotation rotation;
		private readonly IUserInput userInput;
		private readonly SnakeFollowCamera followCamera;
		private readonly SnakeSegmentController segmentController;
		private readonly SnakeHeadView headView;
		private readonly SignalBus signalBus;
		private readonly SnakePath path;

		private bool isStopped;

		public bool CleanUped { get; private set; }

		public SnakeModel(SnakeHeadView headView, SnakeMove move, SnakeRotation rotation, IUserInput userInput, SnakeFollowCamera followCamera,
			SnakeSegmentController segmentController, SignalBus signalBus, SnakePath path, ICleanUpService cleanUpService)
		{
			this.path = path;
			this.signalBus = signalBus;
			this.headView = headView;
			headView.BonusHit += PickUpBonus;
			headView.ObstacleHit += OnHit;
			headView.SegmentHit += OnHit;
			this.segmentController = segmentController;
			this.followCamera = followCamera;
			this.userInput = userInput;
			this.rotation = rotation;
			this.move = move;
			signalBus.Subscribe<PickUpBonusSignal>(OnPickUpBonus);
			signalBus.Subscribe<FinishGameSignal>(OnGameFinish);
			cleanUpService.Register(this);
		}

		public void CleanUp()
		{
			CleanUped = true;
			headView.BonusHit -= PickUpBonus;
			headView.ObstacleHit -= OnHit;
			headView.SegmentHit -= OnHit;
			signalBus.Unsubscribe<PickUpBonusSignal>(OnPickUpBonus);
			signalBus.Unsubscribe<FinishGameSignal>(OnGameFinish);
		}

		public void Update(float deltaTime)
		{
			if (isStopped)
				return;

			move.Move(deltaTime, headView.SnakeBody);
			rotation.Rotate( headView.SnakeBody, (userInput.CursorPosition -  headView.SnakeBody.position).normalized);
			segmentController.MoveSegments(deltaTime);
			path.Update(segmentController.Segments, deltaTime);
			followCamera.ChangePosition( headView.SnakeBody.position);
		}

		private void OnPickUpBonus() =>
			segmentController.Grow();

		private void PickUpBonus(Bonus bonus) =>
			bonus.PickUp();

		private void OnHit() =>
			signalBus.Fire(new SnakeHitSignal());

		private void OnGameFinish() =>
			isStopped = true;
	}
}