using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PieShop.Models;
using PieShop.ViewModels;

namespace PieShop.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IPieRepository _pieRepository;

		public HomeController(ILogger<HomeController> logger, IPieRepository pieRepository)
		{
			_logger = logger;
			_pieRepository = pieRepository;
		}

		public IActionResult Index()
		{
			HomeViewModel homeView = new HomeViewModel
			{
				PiesOfTheWeek = _pieRepository.PiesOfTheWeek
			};

			return View(homeView);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
