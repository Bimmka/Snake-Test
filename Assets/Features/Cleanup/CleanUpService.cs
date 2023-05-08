using System.Collections.Generic;

namespace Features.Cleanup
{
	public class CleanUpService : ICleanUpService
	{
		private readonly List<ICleanUp> cleanups = new List<ICleanUp>(10);
		public void Register(ICleanUp cleanup)
		{
			cleanups.Add(cleanup);
		}

		public void CleanUp()
		{
			for (int i = 0; i < cleanups.Count; i++)
			{
				if (cleanups[i] != null && cleanups[i].CleanUped == false)
					cleanups[i].CleanUp();
			}
			cleanups.Clear();
		}
	}
}