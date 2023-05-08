using Features.Bonuses.Data;
using Features.FollowCamera.Data;
using Features.Level.Data;
using Features.Snake.Data;
using Features.UI.Data;
using UnityEngine;
using Zenject;

namespace Features.Bootstrapp.Scripts
{
	[CreateAssetMenu( fileName = "Data Installer", menuName = "Bootstrapp/Create DataInstaller", order = 52)]
	public class DataInstaller : ScriptableObjectInstaller
	{
		[SerializeField] private FollowCameraSettings followCameraSettings;
		[SerializeField] private SnakeSettings snakeSettings;
		[SerializeField] private BonusCooldownSettings bonusCooldownSettings;
		[SerializeField] private LevelSettings levelSettings;
		[SerializeField] private WindowsVisualData visualData;

		public override void InstallBindings()
		{
			Container.Bind<FollowCameraSettings>().To<FollowCameraSettings>().FromInstance(followCameraSettings);
			Container.Bind<SnakeSettings>().To<SnakeSettings>().FromInstance(snakeSettings);
			Container.Bind<BonusCooldownSettings>().To<BonusCooldownSettings>().FromInstance(bonusCooldownSettings);
			Container.Bind<LevelSettings>().To<LevelSettings>().FromInstance(levelSettings);
			Container.Bind<WindowsVisualData>().To<WindowsVisualData>().FromInstance(visualData);
		}
	}
}