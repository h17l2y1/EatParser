using AutoMapper;
using EatParser.DataAccess.Repositories.Interfaces;
using EatParser.Entities.Entities;
using EatParser.Services.Providers.Interfaces;
using EatParser.Services.Services.Interfaces;
using EatParser.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Services
{
	public class RolService : IRoleService
	{
		private readonly IMapper _mapper;
		private readonly IYaposhkaProvider _yaposhkaProvider;
		private readonly IMafiaProvider _mafiaProvider;
		private readonly IRoleSetRepository _roleSetRepository;

		public RolService(IYaposhkaProvider yaposhkaProvider, IMapper mapper, IMafiaProvider mafiaProvider, IRoleSetRepository roleSetRepository)
		{
			_mapper = mapper;
			_yaposhkaProvider = yaposhkaProvider;
			_mafiaProvider = mafiaProvider;
			_roleSetRepository = roleSetRepository;
		}

		public async Task<RolSetView> GetYaposhkaSets(string str)
		{
			var listEntity = await _yaposhkaProvider.GetYaposhkaSets();
			var model = _mapper.Map<List<SetView>>(listEntity);
			RolSetView view = new RolSetView(model);
			return view;
		}

		public async Task<RolSetView> GetMafiaSets(string str)
		{
			var listEntity = await _mafiaProvider.GetMafiaSets();

			RolSet set = listEntity[0];

			await _roleSetRepository.Add(set);

			var model = _mapper.Map<List<SetView>>(listEntity);
			RolSetView view = new RolSetView(model);

			return view;
		}

	}
}
