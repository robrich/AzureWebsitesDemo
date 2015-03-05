namespace AzureWebsitesDemo.Data {
	using System;
	using System.ComponentModel.DataAnnotations;

	public class Event {
		[Key]
		public int EventId { get; set; }
		public DateTime EventDate { get; set; }
		[Required]
		[StringLength(50)]
		public string Description { get; set; }
	}
}
