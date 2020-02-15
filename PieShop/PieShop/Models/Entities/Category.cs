using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
	public class Category
	{
		public int Id { get; set; }

		[Required, StringLength(100)]
		public string Name { get; set; }
		public string Description { get; set; }
		public List<Pie> Pies { get; set; }
	}
}
