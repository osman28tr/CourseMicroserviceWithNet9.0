using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMicroservice.Order.Domain.Entities
{
	public class OrderItem : BaseEntity<int>
	{
		public Guid ProductId { get; set; }
		public string ProductName { get; set; } = default!;
		public string UnitPrice { get; set; }

		public void SetItem
	}
}
