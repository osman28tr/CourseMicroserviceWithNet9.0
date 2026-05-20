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
		public Guid OrderId { get; set; }
		public string ProductName { get; set; } = default!;
		public decimal UnitPrice { get; set; }
		public Order Order { get; set; }
	}
}
