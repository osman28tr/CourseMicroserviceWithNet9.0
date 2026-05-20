using CourseMicroservice.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMicroservice.Order.Persistance
{
	public class AppDbContext (DbContextOptions<AppDbContext> options) : DbContext(options)
	{
		public DbSet<CourseMicroservice.Order.Domain.Entities.Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
	}
}
