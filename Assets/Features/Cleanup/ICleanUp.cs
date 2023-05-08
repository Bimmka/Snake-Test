namespace Features.Cleanup
{
	public interface ICleanUp
	{
		bool CleanUped { get; }
		void CleanUp();
	}
}