using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
	public interface IPieRepository
	{
		IEnumerable<Pie> Pies { get; }
		IEnumerable<Pie> PiesOfTheWeek { get; }

		Pie GetPieById(int id);
	}
}
