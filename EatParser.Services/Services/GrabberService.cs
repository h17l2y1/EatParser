using AutoMapper;
using EatParser.DataAccess.Repositories.Interfaces;
using EatParser.Entities.Entities;
using EatParser.Services.Providers.Interfaces;
using EatParser.Services.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Services
{
	public class GrabberService : IGrabberService
	{
		private readonly IYaposhkaProvider _yaposhkaProvider;
		private readonly IMafiaProvider _mafiaProvider;
		private readonly IRolSetRepository _roleSetRepository;

		public GrabberService(IYaposhkaProvider yaposhkaProvider, IMafiaProvider mafiaProvider, IRolSetRepository roleSetRepository)
		{
			_yaposhkaProvider = yaposhkaProvider;
			_mafiaProvider = mafiaProvider;
			_roleSetRepository = roleSetRepository;
		}

		public async Task GrabbAllRestaurant()
		{
			await GrabbYaposhkaSets();
			await GrabbMafiaSets();
		}

		public async Task GrabbYaposhkaSets()
		{
			List<RolSet> listEntity = await _yaposhkaProvider.GetYaposhkaSets();
			await _roleSetRepository.AddRange(listEntity);
		}

		public async Task GrabbMafiaSets()
		{
			List<RolSet> listEntity = await _mafiaProvider.GetMafiaSets();
			await _roleSetRepository.AddRange(listEntity);
		}


	}
}
