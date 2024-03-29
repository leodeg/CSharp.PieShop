﻿using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Components
{
	public class CategoryMenu : ViewComponent
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoryMenu(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}
		 
		public IViewComponentResult Invoke()
		{
			var categories = _categoryRepository.Categories.OrderBy(c => c.Name);
			return View(categories);
		}
	}
}
