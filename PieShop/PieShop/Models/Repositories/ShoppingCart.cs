using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PieShop.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
	public class ShoppingCart
	{
		private readonly ApplicationDbContext _context;

		public string ShoppingCartId { get; set; }
		public List<ShoppingCartItem> ShoppingCartItems { get; set; }

		public ShoppingCart(ApplicationDbContext context)
		{
			_context = context;
		}

		public static ShoppingCart GetCard(IServiceProvider services)
		{
			if (services == null)
				throw new ArgumentNullException();

			try
			{
				ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
				ApplicationDbContext context = services.GetService<ApplicationDbContext>();

				string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
				session.SetString("CartId", cartId);

				return new ShoppingCart(context) { ShoppingCartId = cartId };
			}
			catch (InvalidOperationException ex)
			{
				Trace.WriteLine(ex.Message);
				throw new InvalidOperationException(ex.StackTrace);
			}
		}

		public void AddToCart(Pie pie, int amount)
		{
			var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
				s => s.Pie.Id == pie.Id && s.ShoppingCartId == ShoppingCartId);

			if (shoppingCartItem == null)
				_context.ShoppingCartItems.Add(CreateNewShoppingCartItem(pie, amount));
			else shoppingCartItem.Amount += amount;

			_context.SaveChanges();
		}

		private ShoppingCartItem CreateNewShoppingCartItem(Pie pie, int amount)
		{
			return new ShoppingCartItem
			{
				ShoppingCartId = this.ShoppingCartId,
				Pie = pie,
				Amount = amount
			};
		}

		public int RemoveFromCart(Pie pie)
		{
			var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
				s => s.Pie.Id == pie.Id && s.ShoppingCartId == ShoppingCartId);

			int localAmount = 0;
			if (shoppingCartItem != null)
			{
				if (shoppingCartItem.Amount > 1)
				{
					shoppingCartItem.Amount--;
					localAmount = shoppingCartItem.Amount;
				}
				else
				{
					_context.ShoppingCartItems.Remove(shoppingCartItem);
				}
			}

			_context.SaveChanges();
			return localAmount;
		}

		public List<ShoppingCartItem> GetShoppingCartItems()
		{
			return ShoppingCartItems ??
				(ShoppingCartItems = _context.ShoppingCartItems
					.Where(c => c.ShoppingCartId == this.ShoppingCartId)
					.Include(s => s.Pie)
					.ToList());
		}

		public void ClearCart()
		{
			var cartItems = _context.ShoppingCartItems
				.Where(cart => cart.ShoppingCartId == this.ShoppingCartId);
			_context.ShoppingCartItems.RemoveRange(cartItems);
			_context.SaveChanges();
		}

		public decimal GetShoppingCartTotalPrice()
		{
			return _context.ShoppingCartItems
				.Where(c => c.ShoppingCartId == this.ShoppingCartId)
				.Select(c => c.Pie.Price * c.Amount)
				.Sum();
		}
	}
}
