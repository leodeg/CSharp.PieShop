using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.ViewModels;

namespace PieShop.Controllers
{
	public class ShoppingCartController : Controller
	{
		private readonly IPieRepository _pieRepository;
		private readonly ShoppingCart _shoppingCart;

		public ShoppingCartController(IPieRepository pieRepository, ShoppingCart shoppingCart)
		{
			_pieRepository = pieRepository;
			_shoppingCart = shoppingCart;
		}

		public ViewResult Index()
		{
			_shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();

			var shoppingCartVM = new ShoppingCartViewModel
			{
				ShoppingCart = _shoppingCart,
				ShoppingCartTotal = _shoppingCart.GetShoppingCartTotalPrice()
			};

			return View(shoppingCartVM);
		}

		public RedirectToActionResult AddToShoppingCart(int id)
		{
			var selectedPie = _pieRepository.Pies
				.FirstOrDefault(p => p.Id == id);

			if (selectedPie != null)
				_shoppingCart.AddToCart(selectedPie, 1);
			else return RedirectToAction("Error");

			return RedirectToAction("Index");
		}

		public RedirectToActionResult RemoveFromShoppingCart(int id)
		{
			var selectedPie = _pieRepository.Pies
				.FirstOrDefault(p => p.Id == id);

			if (selectedPie != null)
				_shoppingCart.RemoveFromCart(selectedPie);

			return RedirectToAction("Index");
		}
	}
}