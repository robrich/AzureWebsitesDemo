namespace AzureWebsitesDemo.WebJob {
	using System;
	using System.Threading;

	public static class Program {
		public static void Main(string[] args) {
			while (true) {
				Thread.Sleep(1000);
			}
		}
	}
}
