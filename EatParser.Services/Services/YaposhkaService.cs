using AutoMapper;
using EatParser.Services.Providers.Interfaces;
using EatParser.Services.Services.Interfaces;
using EatParser.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Services
{
	public class YaposhkaService : IYaposhkaService
	{
		private readonly IYaposhkaProvider _yaposhkaProvider;
		private readonly IMapper _mapper;

		public YaposhkaService(IYaposhkaProvider yaposhkaProvider, IMapper mapper)
		{
			_yaposhkaProvider = yaposhkaProvider;
			_mapper = mapper;
		}

		public async Task<SushiSetView> GetYaposhkaSets(string str)
		{
			var listEntity = await _yaposhkaProvider.GetYaposhkaSets();


			var model = _mapper.Map<List<SetView>>(listEntity);

			SushiSetView view = new SushiSetView(model);

			return view;
		}


	}
}
