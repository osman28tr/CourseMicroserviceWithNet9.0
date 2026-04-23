using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMicroservice.Order.Domain.Entities
{
	public class BaseEntity<TEntityId>
	{
		public TEntityId EntityId { get; set; } = default!;
	}
}
