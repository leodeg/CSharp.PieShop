using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
	public interface ICategoryRepository
	{
		IEnumerable<Category> Categories { get; }
	}
}
