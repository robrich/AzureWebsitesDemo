namespace AzureWebsitesDemo.Web.Controllers {
	using System.Collections.Generic;
	using System.Web.Mvc;
	using AzureWebsitesDemo.Data;

	public class QueueController : Controller {
		private readonly QueueRepository queueRepository = new QueueRepository();

		public ActionResult Index() {
			List<string> messages = this.queueRepository.EmptyQueue();
			return this.View(messages);
		}

		public ActionResult NewMessage(string Content) {
			this.queueRepository.AddMessage(Content);
			return this.RedirectToAction("Index");
		}

	}
}
