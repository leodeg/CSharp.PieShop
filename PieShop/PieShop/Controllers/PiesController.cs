using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PieShop.Data;
using PieShop.Models;
using PieShop.ViewModels;

namespace PieShop.Controllers
{
	public class PiesController : Controller
	{
		private ApplicationDbContext _context;

		private readonly IPieRepository pieRepository;
		private readonly ICategoryRepository categoryRepository;

		public PiesController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
		{
			this.pieRepository = pieRepository;
			this.categoryRepository = categoryRepository;
		}

		public IActionResult Index()
		{
			return View();
		}

		public ViewResult List()
		{
			var piesList = new PiesListViewModel();
			piesList.Pies = pieRepository.Pies;
			piesList.CurrentCategory = "Cheese cakes";

			return View(piesList);
		}
	}
}