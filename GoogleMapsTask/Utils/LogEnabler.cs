using System.Diagnostics;

internal class LogEnabler
{
	[SetUpFixture]
	public class SetupTrace
	{
		[OneTimeSetUp]
		public void StartTest()
		{
			Trace.Listeners.Add(new ConsoleTraceListener());
		}

		[OneTimeTearDown]
		public void EndTest()
		{
			Trace.Flush();
		}
	}
}