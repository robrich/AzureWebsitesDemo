namespace AzureWebsitesDemo.Web.Controllers {
	using System.Collections.Generic;
	using System.Web.Mvc;
	using AzureWebsitesDemo.Data;

	public class EventController : Controller {
		private readonly EventRepository eventRepository = new EventRepository();
		private readonly QueueRepository queueRepository = new QueueRepository();

		public ActionResult Index() {
			List<Event> events = this.eventRepository.GetEvents();
			return this.View(events);
		}

		public ActionResult NewMessage(string Content) {
			this.queueRepository.AddMessage(Content);
			return this.RedirectToAction("Index");
		}

	}
}
