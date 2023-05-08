namespace Features.Cleanup
{
	public interface ICleanUpService
	{
		void CleanUp();
		void Register(ICleanUp cleanup);
	}
}