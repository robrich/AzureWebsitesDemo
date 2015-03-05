namespace AzureWebsitesDemo.Web.Controllers {
	using System.Collections.Generic;
	using System.Web.Mvc;
	using AzureWebsitesDemo.Data;

	public class EventController : Controller {
		private readonly EventRepository eventRepository = new EventRepository();

		public ActionResult Index() {
			List<Event> events = this.eventRepository.GetEvents();
			return this.View(events);
		}

	}
}
