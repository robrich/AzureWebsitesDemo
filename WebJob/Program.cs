namespace AzureWebsitesDemo.WebJob {
	using System;
	using System.Threading;

	public static class Program {
		public static void Main(string[] args) {
			while (true) {
				Console.WriteLine("Running: " + DateTime.Now.ToString("G"));
				Thread.Sleep(1000);
			}
		}
	}
}
