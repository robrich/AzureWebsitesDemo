namespace AzureWebsitesDemo.Data {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class EventRepository {

		public Event SaveEvent(string Description) {
			Event e = new Event {
				Description = Description,
				EventDate = DateTime.Now
			};
			using (AzureWebsitesDemoContext db = new AzureWebsitesDemoContext()) {
				db.Events.Add(e);
				db.SaveChanges();
			}
			return e;
		}

		public List<Event> GetEvents() {
			using (AzureWebsitesDemoContext db = new AzureWebsitesDemoContext()) {
				return (
					from e in db.Events
					orderby e.EventId descending
					select e
				).ToList();
			}
		}

	}
}
