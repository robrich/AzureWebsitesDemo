namespace AzureWebsitesDemo.Data {
	using System.Data.Entity;

	public class AzureWebsitesDemoContext : DbContext {
		public AzureWebsitesDemoContext() : base("DefaultConnection") {
		}

		public IDbSet<Event> Events { get; set; }
	}
}
