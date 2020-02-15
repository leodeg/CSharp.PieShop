using Microsoft.EntityFrameworkCore;
using PieShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
	public class PieRepository : IPieRepository
	{
		private readonly ApplicationDbContext _context;

		public PieRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Pie> Pies
		{
			get
			{
				return _context.Pies.Include(p => p.Category);
			}
		}

		public IEnumerable<Pie> PiesOfTheWeek
		{
			get
			{
				return _context.Pies.Include(p => p.Category).Where(p => p.IsPieOfWeek);
			}
		}

		public Pie GetPieById(int id)
		{
			return _context.Pies.FirstOrDefault(p => p.Id == id);
		}
	}
}
