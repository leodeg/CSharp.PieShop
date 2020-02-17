using AutoMapper;
using PieShop.Models;
using PieShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Data
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Pie, PieViewModel>();
			CreateMap<PieViewModel, Pie>();
		}
	}
}
