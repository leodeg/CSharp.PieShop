using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
	public class OrderDetail
	{
		[Key]
		public int OrderDetailId { get; set; }

		[ForeignKey("Order")]
		public int OrderId { get; set; }

		[ForeignKey("Pie")]
		public int PieId { get; set; }

		public int Amount { get; set; }
		public decimal Price { get; set; }
		public virtual Pie Pie { get; set; }
		public virtual Order Order { get; set; }

	}
}
