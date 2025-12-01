using System.ComponentModel.DataAnnotations;

namespace CourseMicroservice.Catalog.API.Options
{
	public class MongoOption
	{
		[Required]
		public string DatabaseName { get; set; }
		[Required]
		public string ConnectionString { get; set; }
	}
}
