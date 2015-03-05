namespace AzureWebsitesDemo.Web.Controllers {
	using System.Web.Mvc;
	using AzureWebsitesDemo.Data;

	public class HomeController : Controller {
		private readonly EventRepository eventRepository = new EventRepository();

		public ActionResult Index() {
			this.eventRepository.SaveEvent("Home page loaded");
			return this.View();
		}

		public ActionResult About() {
			this.ViewBag.Message = "The application description page.";

			return this.View();
		}

		public ActionResult Contact() {
			this.ViewBag.Message = "Your contact page.";

			return this.View();
		}
	}
}