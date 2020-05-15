using EatParser.DataAccess.Repositories.Interfaces;
using EatParser.Entities.Entities;
using EatParser.Entities.Types;
using EatParser.Services.Helpers.Interfaces;
using EatParser.Services.Providers;
using EatParser.Services.Providers.Interfaces;
using EatParser.Services.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
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
		private readonly IRestaurantRepository _restaurandRepository;

		private readonly IHtmlLoaderHelper _htmlLoaderHelper;
		private readonly IConfiguration _сonfiguration;
		private readonly IMafiaHelper _mafiaHelper;
		private readonly IYaposhkaHelper _yaposhkaHelper;

		private IProviderFactory[] providers;

		public GrabberService(IYaposhkaProvider yaposhkaProvider, IMafiaProvider mafiaProvider, ISushiPapaProvider sushiPapaProvider,
			IRollClubProvider rollClubProvider, ISetRepository setRepository, IRolRepository rolRepository, ISushiRepository sushiRepository,
			IPizzaRepository pizzaRepository, IRestaurantRepository restaurandRepository,

			IHtmlLoaderHelper htmlLoaderHelper, IConfiguration сonfiguration, IMafiaHelper mafia, IYaposhkaHelper yaposhka
			)
		{
			_yaposhkaProvider = yaposhkaProvider;
			_mafiaProvider = mafiaProvider;
			_setRepository = setRepository;
			_rolRepository = rolRepository;
			_sushiRepository = sushiRepository;
			_pizzaRepository = pizzaRepository;
			_sushiPapaProvider = sushiPapaProvider;
			_rollClubProvider = rollClubProvider;
			_restaurandRepository = restaurandRepository;

			_htmlLoaderHelper = htmlLoaderHelper;
			_сonfiguration = сonfiguration;
			_mafiaHelper = mafia;
			_yaposhkaHelper = yaposhka;
		}

		public async Task GrabbAllRestaurant()
		{
			await CreateProviders();

			for (int i = 0; i < providers.Length; i++)
			{
				IEnumerable<Set> sets = await providers[i].GetSets();
				IEnumerable<Rol> rols = await providers[i].GetRols();
				IEnumerable<Sushi> sushi = await providers[i].GetSushi();
				IEnumerable<Pizza> pizza = await providers[i].GetPizza();

				await SaveAll(sets, rols, sushi, pizza);
			}
		}

		private async Task CreateProviders()
		{
			providers = new IProviderFactory[] {
				new MafiaProviderFactory(_htmlLoaderHelper, _сonfiguration, _mafiaHelper, await GetRestaurantByName(RestaurantType.Mafia.ToString())),
				new YaposhkaProviderFactory(_htmlLoaderHelper, _сonfiguration, _yaposhkaHelper, await GetRestaurantByName(RestaurantType.Yaposhka.ToString())),
				//new SushiPapaProviderFactory(_htmlLoaderHelper, _сonfiguration, _sushiPapaProvider, await GetRestaurantByName(RestaurantType.SushiPapa.ToString())),
				//new RollClubProviderFactory(_htmlLoaderHelper, _сonfiguration, _rollClubProvider, await GetRestaurantByName(RestaurantType.RollClub.ToString()))

			};
		}

		private async Task<Restaurant> GetRestaurantByName(string name)
		{
			Restaurant rest = await _restaurandRepository.GetRestaurantByName(name);
			return rest;
		}

		public async Task GrabbMafia()
		{
			IEnumerable<Set> sets = await _mafiaProvider.GetSets();
			IEnumerable<Rol> rols = await _mafiaProvider.GetRols();
			IEnumerable<Sushi> sushi = await _mafiaProvider.GetSushi();
			IEnumerable<Pizza> pizza = await _mafiaProvider.GetPizza();

			await SaveAll(sets, rols, sushi, pizza);
		}

		public async Task GrabbYaposhka()
		{
			IEnumerable<Set> sets = await _yaposhkaProvider.GetSets();
			IEnumerable<Rol> rols = await _yaposhkaProvider.GetRols();
			IEnumerable<Sushi> sushi = await _yaposhkaProvider.GetSushi();
			IEnumerable<Pizza> pizza = await _yaposhkaProvider.GetPizza();

			await SaveAll(sets, rols, sushi, pizza);
		}

		public async Task GrabbSushiPapa()
		{
			IEnumerable<Set> sets = await _sushiPapaProvider.GetSets();
			IEnumerable<Rol> rols = await _sushiPapaProvider.GetRols();
			IEnumerable<Sushi> sushi = await _sushiPapaProvider.GetSushi();

			await SaveAll(sets, rols, sushi, null);
		}

		public async Task GrabbRollClub()
		{
			IEnumerable<Set> sets = await _rollClubProvider.GetSets();
			IEnumerable<Rol> rols = await _rollClubProvider.GetRols();
			IEnumerable<Sushi> sushi = await _rollClubProvider.GetSushi();

			await SaveAll(sets, rols, sushi, null);
		}

		private async Task SaveAll(IEnumerable<Set> sets, IEnumerable<Rol> rols, IEnumerable<Sushi> sushi, IEnumerable<Pizza> pizza)
		{
			await _setRepository.AddRange(sets);
			await _rolRepository.AddRange(rols);
			await _sushiRepository.AddRange(sushi);
			await _pizzaRepository.AddRange(pizza);
		}
	}
}
