using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMicroservice.Order.Domain.Entities
{
	public class Order : BaseEntity<Guid>
	{
		public string Code { get; set; }
		public Guid BuyerId { get; set; }
		public Guid PaymentId { get; set; }
		public int AddressId { get; set; }
		public decimal TotalPrice { get; set; }
		public float? DiscountRate { get; set; }
		public DateTime CreatedDate { get; set; }
		public OrderStatus OrderStatus { get; set; }
		public OrderAddress OrderAddresses { get; set; }
		public List<OrderItem> OrderItems { get; set; }

		public static string GenerateCode()
		{
			var random = new Random();
			var code = random.Next(100000, 999999).ToString();
			return code;
		}

		public static Order CreateUnPaidOrder(Guid buyerId,float? discountRate,int addressId)
		{
			return new Order
			{
				Id = NewId.NextSequentialGuid(),
				Code = GenerateCode(),
				BuyerId = buyerId,
				OrderStatus = OrderStatus.WaitingForPayment,
				CreatedDate = DateTime.UtcNow,
				TotalPrice = 0,
				AddressId = addressId,
				DiscountRate = discountRate
			};
		}

		public void AddOrderItem(Guid productId, string productName, decimal unitPrice)
		{
			if (OrderItems == null)
				OrderItems = new List<OrderItem>();
			OrderItems.Add(new OrderItem
			{
				ProductId = productId,
				ProductName = productName,
				UnitPrice = unitPrice
			});
			CalculateTotalPrice();
		}
		
		private void CalculateTotalPrice()
		{
			if (OrderItems != null && OrderItems.Count > 0)
			{
				TotalPrice = OrderItems.Sum(x => x.UnitPrice);
				if (DiscountRate.HasValue)
				{
					TotalPrice = TotalPrice - (TotalPrice * (decimal)DiscountRate.Value / 100);
				}
			}
		}
		public void SetPaidStatus(Guid paymentId)
		{
			OrderStatus = OrderStatus.Paid;
			this.PaymentId = paymentId;
		}
	}
	public class OrderAddress : BaseEntity<int>
	{
		public string Province { get; set; }
		public string District { get; set; }
		public string Street { get; set; }
		public string ZipCode { get; set; }
		public string Line { get; set; }
	}
	public enum OrderStatus
	{
		WaitingForPayment = 1,
		Paid = 2,
		Canceled = 3,
	}
}
