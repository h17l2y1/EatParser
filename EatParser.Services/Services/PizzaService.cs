using AutoMapper;
using EatParser.DataAccess.Repositories.Interfaces;
using EatParser.Services.Services.Interfaces;
using EatParser.ViewModels.Pizza;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Services
{
	public class PizzaService : IPizzaService
	{
		private readonly IMapper _mapper;
		private readonly IPizzaRepository _roleSetRepository;

		public PizzaService(IMapper mapper, IPizzaRepository roleSetRepository)
		{
			_mapper = mapper;
			_roleSetRepository = roleSetRepository;
		}

		public async Task<GetAllPizzaView> GetAllSetsAsync()
		{
			var listEntity = await _roleSetRepository.GetAll();
			var model = _mapper.Map<List<GetAllPizzaViewItem>>(listEntity);
			GetAllPizzaView view = new GetAllPizzaView(model);

			return view;
		}
	}
}
