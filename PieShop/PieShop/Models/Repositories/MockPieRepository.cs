using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
	public class MockPieRepository : IPieRepository
	{
		private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

		public IEnumerable<Pie> Pies
		{
			get
			{
				return new List<Pie>
				{
					new Pie {Id = 0, Name = "Pie Name", LongDescription = "Pie Long Description", ImageThumbnailUrl="/img/carousel1.jpg", ShortDescription= "Short description" },
					new Pie {Id = 1, Name = "Pie Name 2", LongDescription = "Pie Long Description 2", ImageThumbnailUrl="/img/carousel2.jpg", ShortDescription= "Short description" },
					new Pie {Id = 2, Name = "Pie Name 3", LongDescription = "Pie Long Description 3",ImageThumbnailUrl="/img/carousel3.jpg", ShortDescription= "Short description" }
				};
			}
		}

		public IEnumerable<Pie> PiesOfTheWeek => throw new NotImplementedException();

		public Pie GetPieById(int id)
		{
			throw new NotImplementedException();
		}
	}
}
