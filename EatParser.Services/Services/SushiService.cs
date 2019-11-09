using AutoMapper;
using EatParser.Services.Providers.Interfaces;
using EatParser.Services.Services.Interfaces;
using EatParser.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Services
{
	public class SushiService : ISushiService
	{
		private readonly IMapper _mapper;
		private readonly IYaposhkaProvider _yaposhkaProvider;
		private readonly IMafiaProvider _mafiaProvider;

		public SushiService(IYaposhkaProvider yaposhkaProvider, IMapper mapper, IMafiaProvider mafiaProvider)
		{
			_mapper = mapper;
			_yaposhkaProvider = yaposhkaProvider;
			_mafiaProvider = mafiaProvider;
		}

		public async Task<SushiSetView> GetYaposhkaSets(string str)
		{
			var listEntity = await _yaposhkaProvider.GetYaposhkaSets();
			var model = _mapper.Map<List<SetView>>(listEntity);
			SushiSetView view = new SushiSetView(model);
			return view;
		}

		public async Task<SushiSetView> GetMafiaSets(string str)
		{
			var listEntity = await _mafiaProvider.GetMafiaSets();
			var model = _mapper.Map<List<SetView>>(listEntity);
			SushiSetView view = new SushiSetView(model);

			return view;
		}

	}
}
