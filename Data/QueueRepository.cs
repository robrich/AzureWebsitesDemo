namespace AzureWebsitesDemo.Data {
	using System.Collections.Generic;
	using System.Configuration;
	using Microsoft.WindowsAzure.Storage;
	using Microsoft.WindowsAzure.Storage.Queue;

/*
 * Queue names must be:
 * - only lower-case letters, numbers, and dash
 * - start with letter, can't end in dash
 * - 3 to 63 characters long
 * http://msdn.microsoft.com/en-us/library/dd179349.aspx
 *
 * Must put AzureWebJobsDashboard in Azure Portal to get Azure Portal Dashboard to work, app.config is insufficient
 * http://blogs.blackmarble.co.uk/blogs/sspencer/post/2014/09/22/5-Tips-for-using-Azure-Web-Jobs.aspx
 */

	public class QueueRepository {
		private readonly CloudQueue webjobsqueue;

		public const string QUEUE_NAME = "webjobsqueue";

		public QueueRepository() {
			CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureWebJobsStorage"].ToString());

			CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
			//queueClient.DefaultRequestOptions.RetryPolicy = new LinearRetry(TimeSpan.FromSeconds(3), 3);

			this.webjobsqueue = queueClient.GetQueueReference(QUEUE_NAME);
			this.webjobsqueue.CreateIfNotExists();
		}

		public void AddMessage(string Content) {
			CloudQueueMessage message = new CloudQueueMessage(Content);
			this.webjobsqueue.AddMessage(message);
		}

		public List<string> EmptyQueue() {

			this.webjobsqueue.FetchAttributes();
			int queuecount = this.webjobsqueue.ApproximateMessageCount ?? 0;
			List<string> contents = new List<string>();
			if (queuecount > 0) {
				while (true) {
					CloudQueueMessage message = this.webjobsqueue.GetMessage();
					if (message == null) {
						break; // all done
					}

					contents.Add(message.AsString);
					// Process the message in less than 30 seconds before it becomes visible to someone else

					this.webjobsqueue.DeleteMessage(message);
				}
			}

			return contents;
		}

	}
}
