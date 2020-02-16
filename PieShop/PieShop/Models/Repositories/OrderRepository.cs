using PieShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
	public class OrderRepository : IOrderRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly ShoppingCart _cart;

		public OrderRepository(ApplicationDbContext context, ShoppingCart cart)
		{
			_context = context;
			_cart = cart;
		}

		public void CreateOrder(Order order)
		{
			if (order == null)
				throw new ArgumentNullException();

			order.OrderPlaced = DateTime.Now;
			_context.Orders.Add(order);

			foreach (var orderInfo in _cart.ShoppingCartItems)
			{
				OrderDetail orderDetail = new OrderDetail
				{
					Order = order,
					Pie = orderInfo.Pie,
					OrderId = order.OrderId,
					PieId = orderInfo.Pie.Id,
					Amount = orderInfo.Amount,
					Price = orderInfo.Pie.Price
				};
				_context.OrderDetails.Add(orderDetail);
			}

			_context.SaveChanges();
		}
	}
}
