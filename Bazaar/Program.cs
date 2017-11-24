namespace Bazaar
{
	class Program
	{
		/// <summary>
		/// Creates a handler objects and starts the stores.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			Handler bazaar = new Handler();
			bazaar.Start();
		}
	}
}
