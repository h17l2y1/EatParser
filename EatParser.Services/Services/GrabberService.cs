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
		private readonly ISushiPapaProvider _sushiPapaProvider;
		private readonly IRollClubProvider _rollClubProvider;

		private readonly ISetRepository _setRepository;
		private readonly IRolRepository _rolRepository;
		private readonly ISushiRepository _sushiRepository;
		private readonly IPizzaRepository _pizzaRepository;

		public GrabberService(IYaposhkaProvider yaposhkaProvider, IMafiaProvider mafiaProvider, ISushiPapaProvider sushiPapaProvider,
			IRollClubProvider rollClubProvider, ISetRepository setRepository, IRolRepository rolRepository, ISushiRepository sushiRepository,
			IPizzaRepository pizzaRepository)
		{
			_yaposhkaProvider = yaposhkaProvider;
			_mafiaProvider = mafiaProvider;
			_setRepository = setRepository;
			_rolRepository = rolRepository;
			_sushiRepository = sushiRepository;
			_pizzaRepository = pizzaRepository;
			_sushiPapaProvider = sushiPapaProvider;
			_rollClubProvider = rollClubProvider;
		}

		public async Task GrabbAllRestaurant()
		{
			await GrabbYaposhka();
			await GrabbMafia();
			await GrabbSushiPapa();
			await GrabbRollClub();
		}

		public async Task GrabbYaposhka()
		{
			List<Set> sets = await _yaposhkaProvider.GetSets();
			List<Rol> rols = await _yaposhkaProvider.GetRols();
			List<Sushi> sushi = await _yaposhkaProvider.GetSushi();
			List<Pizza> pizza = await _yaposhkaProvider.GetPizza();

			await SaveAll(sets, rols, sushi, pizza);
		}

		public async Task GrabbMafia()
		{
			List<Set> sets = await _mafiaProvider.GetSets();
			List<Rol> rols = await _mafiaProvider.GetRols();
			List<Sushi> sushi = await _mafiaProvider.GetSushi();
			List<Pizza> pizza = await _mafiaProvider.GetPizza();

			await SaveAll(sets, rols, sushi, pizza);
		}

		public async Task GrabbSushiPapa()
		{
			List<Set> sets = await _sushiPapaProvider.GetSets();
			List<Rol> rols = await _sushiPapaProvider.GetRols();
			List<Sushi> sushi = await _sushiPapaProvider.GetSushi();

			await SaveAll(sets, rols, sushi, null);
		}

		public async Task GrabbRollClub()
		{
			List<Set> sets = await _rollClubProvider.GetSets();
			List<Rol> rols = await _rollClubProvider.GetRols();
			List<Sushi> sushi = await _rollClubProvider.GetSushi();

			await SaveAll(sets, rols, sushi, null);
		}

		private async Task SaveAll(List<Set> sets, List<Rol> rols, List<Sushi> sushi, List<Pizza> pizza)
		{
			await _setRepository.AddRange(sets);
			await _rolRepository.AddRange(rols);
			await _sushiRepository.AddRange(sushi);
			await _pizzaRepository.AddRange(pizza);
		}
	}
}
