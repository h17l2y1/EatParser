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
	public class GrabberService : IGrabberService
	{
		private readonly IMapper _mapper;
		private readonly IYaposhkaProvider _yaposhkaProvider;
		private readonly IMafiaProvider _mafiaProvider;
		private readonly IRolSetRepository _roleSetRepository;

		public GrabberService(IYaposhkaProvider yaposhkaProvider, IMapper mapper, IMafiaProvider mafiaProvider, IRolSetRepository roleSetRepository)
		{
			_mapper = mapper;
			_yaposhkaProvider = yaposhkaProvider;
			_mafiaProvider = mafiaProvider;
			_roleSetRepository = roleSetRepository;
		}

		public async Task<RolSetView> GetYaposhkaSets()
		{
			List<RolSet> listEntity = await _yaposhkaProvider.GetYaposhkaSets();
			await _roleSetRepository.AddRange(listEntity);

			//var model = _mapper.Map<List<SetView>>(listEntity);
			//RolSetView view = new RolSetView(model);
			//return view;
		}

		public async Task<RolSetView> GetMafiaSets()
		{
			List<RolSet> listEntity = await _mafiaProvider.GetMafiaSets();
			await _roleSetRepository.AddRange(listEntity);


			//var model = _mapper.Map<List<SetView>>(listEntity);
			//RolSetView view = new RolSetView(model);

			//return view;
		}

	}
}
