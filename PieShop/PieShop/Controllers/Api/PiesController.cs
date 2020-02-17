using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.ViewModels;

namespace PieShop.Controllers.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class PiesController : Controller
	{
		private readonly IPieRepository _pieRepository;
		private readonly IMapper _mapper;

		public PiesController(IPieRepository pieRepository, IMapper mapper)
		{
			_pieRepository = pieRepository;
			_mapper = mapper;
		}

		// GET: api/Pie
		[HttpGet]
		public IEnumerable<PieViewModel> Get()
		{
			IEnumerable<Pie> dbPies = _pieRepository.Pies.OrderBy(p => p.Id);
			List<PieViewModel> pies = new List<PieViewModel>();

			foreach (Pie pie in dbPies)
				pies.Add(_mapper.Map<PieViewModel>(pie));

			return pies;
		}

		// GET: api/Pie/5
		[HttpGet("{id}", Name = "Get")]
		public PieViewModel Get(int id)
		{
			var pie = _pieRepository.Pies.SingleOrDefault(p => p.Id == id);
			return _mapper.Map<PieViewModel>(pie);
		}

		// POST: api/Pie
		[HttpPost]
		public void Post([FromBody] string value)
		{

		}

		// PUT: api/Pie/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
