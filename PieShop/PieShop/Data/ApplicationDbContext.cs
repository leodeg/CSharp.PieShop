using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PieShop.Models;

namespace PieShop.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public DbSet<Pie> Pies { get; set; }
		public DbSet<Category> Categories { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
	}
}
