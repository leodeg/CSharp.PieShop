﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PieShop.Models;

namespace PieShop.Controllers
{
	[Authorize]
	public class OrderController : Controller
	{
		private readonly IOrderRepository _orderRepository;
		private readonly ShoppingCart _shoppingCart;

		public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
		{
			_orderRepository = orderRepository;
			_shoppingCart = shoppingCart;
		}

		public IActionResult Checkout()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Checkout(Order order)
		{
			_shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();
			if (_shoppingCart.ShoppingCartItems.Count == 0)
				ModelState.AddModelError("", "Your cart is empty, add some pies first");

			if (ModelState.IsValid)
			{
				_orderRepository.CreateOrder(order);
				_shoppingCart.ClearCart();
				return RedirectToAction("CheckoutComplete");
			}

			return View(order);
		}

		public IActionResult CheckoutComplete()
		{
			ViewBag.CheckoutCompleteMessage = "Thanks for your order.";
			return View();
		}
	}
}