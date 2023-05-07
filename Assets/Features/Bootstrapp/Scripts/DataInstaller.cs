using Features.FollowCamera.Data;
using Features.Snake.Data;
using UnityEngine;
using Zenject;

namespace Features.Bootstrapp.Scripts
{
	[CreateAssetMenu( fileName = "Data Installer", menuName = "Bootstrapp/Create DataInstaller", order = 52)]
	public class DataInstaller : ScriptableObjectInstaller
	{
		[SerializeField] private FollowCameraSettings followCameraSettings;
		[SerializeField] private SnakeSettings snakeSettings;

		public override void InstallBindings()
		{
			Container.Bind<FollowCameraSettings>().To<FollowCameraSettings>().FromInstance(followCameraSettings);
			Container.Bind<SnakeSettings>().To<SnakeSettings>().FromInstance(snakeSettings);
		}
	}
}