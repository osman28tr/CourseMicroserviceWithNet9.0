using System.ComponentModel.DataAnnotations;

namespace CourseMicroservice.Discount.API.Options
{
	public class MongoOption
	{
		[Required]
		public string DatabaseName { get; set; }
		[Required]
		public string ConnectionString { get; set; }
	}
}
