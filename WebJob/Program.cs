namespace AzureWebsitesDemo.WebJob {
	using System;
	using System.Threading;
	using AzureWebsitesDemo.Data;
	using Microsoft.Azure.WebJobs;

	public static class Program {
		private static readonly EventRepository eventRepository = new EventRepository();

		public static void Main(string[] args) {
			JobHost host = new JobHost();
			host.RunAndBlock();
		}

		// This magic method name gets automatically called when an item is added to the queue
		// https://github.com/Azure/azure-content/blob/master/articles/websites-dotnet-webjobs-sdk-storage-queues-how-to.md
		public static void ProcessQueueMessage([QueueTrigger(QueueRepository.QUEUE_NAME)] string Content) {
			Console.WriteLine("Got message from queue: " + Content);
			eventRepository.SaveEvent(Content);
		}

	}
}
