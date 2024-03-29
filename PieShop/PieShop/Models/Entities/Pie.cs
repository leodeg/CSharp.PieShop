﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
	public class Pie
	{
		public int Id { get; set; }

		[Required, StringLength(255)]
		public string Name { get; set; }

		public string ShortDescription { get; set; }
		public string LongDescription { get; set; }
		public string AllergyInformation { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
		public string ImageThumbnailUrl { get; set; }
		public bool IsPieOfWeek { get; set; }
		public bool InStock { get; set; }
		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }
	}
}
