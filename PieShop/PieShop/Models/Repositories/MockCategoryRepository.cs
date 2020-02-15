using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
	public class MockCategoryRepository : ICategoryRepository
	{
		public IEnumerable<Category> Categories
		{
			get
			{
				return new List<Category>
				{
					new Category {Id = 1, Name = "Category Name", Description = "Description" },
					new Category {Id = 2, Name = "Category Name 2", Description = "Category Description 2" },
					new Category {Id = 3, Name = "Category Name 3", Description = "Category Description 3" }
				};
			}
		}
	}
}
