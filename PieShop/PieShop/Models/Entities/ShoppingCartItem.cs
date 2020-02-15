using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
	public class ShoppingCartItem
	{
		public int Id { get; set; }
		public Pie Pie { get; set; }
		public int Amount { get; set; }
		public string ShoppingCartId { get; set; }
	}
}
