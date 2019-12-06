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
		private readonly ISetRepository _setRepository;
		private readonly IRolRepository _rolRepository;
		private readonly ISushiRepository _sushiRepository;

		public GrabberService(IYaposhkaProvider yaposhkaProvider, IMafiaProvider mafiaProvider,
			ISetRepository setRepository, IRolRepository rolRepository, ISushiRepository sushiRepository)
		{
			_yaposhkaProvider = yaposhkaProvider;
			_mafiaProvider = mafiaProvider;
			_setRepository = setRepository;
			_rolRepository = rolRepository;
			_sushiRepository = sushiRepository;
		}

		public async Task GrabbAllRestaurant()
		{
			await GrabbYaposhkaSets();
			await GrabbMafiaSets();
		}

		public async Task GrabbYaposhkaSets()
		{
			List<Rol> listEntity = await _yaposhkaProvider.GetYaposhkaSets();
			await _rolRepository.AddRange(listEntity);
		}

		public async Task GrabbMafiaSets()
		{
			List<Set> sets = await _mafiaProvider.GetSets();
			List<Rol> rols = await _mafiaProvider.GetRols();
			List<Sushi> sushi = await _mafiaProvider.GetSushi();

			await _setRepository.AddRange(sets);
			//await _rolRepository.AddRange(rols);
			//await _sushiRepository.AddRange(sushi);
		}


	}
}
