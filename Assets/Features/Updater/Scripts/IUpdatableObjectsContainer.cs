namespace Features.Updater.Scripts
{
	public interface IUpdatableObjectsContainer
	{
		void Register(IUpdatable updatable);
		void Remove(IUpdatable updatable);
	}
}