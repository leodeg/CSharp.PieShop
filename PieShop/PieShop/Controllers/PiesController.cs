using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PieShop.Data;
using PieShop.Models;
using PieShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Controllers
{
	public class PiesController : Controller
	{
		private readonly IPieRepository _pieRepository;
		private readonly ICategoryRepository _categoryRepository;

		public PiesController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
		{
			this._pieRepository = pieRepository;
			this._categoryRepository = categoryRepository;
		}

		public IActionResult Index()
		{
			return View();
		}

        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.Pies.OrderBy(p => p.Id);
                currentCategory = "All pies";
            }
            else
            {
                pies = _pieRepository.Pies.Where(p => p.Category.Name == category)
                   .OrderBy(p => p.Id);
                currentCategory = _categoryRepository.Categories.FirstOrDefault(c => c.Name == category).Name;
            }

            return View(new PiesListViewModel
            {
                Pies = pies,
                CurrentCategory = currentCategory
            });
        }


        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();

            return View(pie);
        }
    }
}