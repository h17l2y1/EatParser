using AutoMapper;
using EatParser.DataAccess.Repositories.Interfaces;
using EatParser.Services.Services.Interfaces;
using EatParser.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Services
{
	public class RolSetService : IRolSetService
	{
		private readonly IMapper _mapper;
		private readonly IRolSetRepository _roleSetRepository;

		public RolSetService(IMapper mapper, IRolSetRepository roleSetRepository)
		{
			_mapper = mapper;
			_roleSetRepository = roleSetRepository;
		}

		public async Task<RolSetView> GetAllSetsAsync()
		{
			var listEntity = await _roleSetRepository.GetAll();
			var model = _mapper.Map<List<SetView>>(listEntity);
			RolSetView view = new RolSetView(model);

			return view;
		}

		public async Task<RolSetView> GetMafiaSets()
		{
			var listEntity = await _roleSetRepository.GetAll();

			var model = _mapper.Map<List<SetView>>(listEntity);
			RolSetView view = new RolSetView(model);

			return view;
		}

		public async Task<RolSetView> GetYaposhkaSets()
		{
			var listEntity = await _roleSetRepository.GetAll();
			var model = _mapper.Map<List<SetView>>(listEntity);
			RolSetView view = new RolSetView(model);

			return view;
		}

	}
}
