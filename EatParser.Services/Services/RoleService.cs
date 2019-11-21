using AutoMapper;
using EatParser.Services.Providers.Interfaces;
using EatParser.Services.Services.Interfaces;
using EatParser.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Services
{
	public class RoleService : IRoleService
	{
		private readonly IMapper _mapper;
		private readonly IYaposhkaProvider _yaposhkaProvider;
		private readonly IMafiaProvider _mafiaProvider;

		public RoleService(IYaposhkaProvider yaposhkaProvider, IMapper mapper, IMafiaProvider mafiaProvider)
		{
			_mapper = mapper;
			_yaposhkaProvider = yaposhkaProvider;
			_mafiaProvider = mafiaProvider;
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
			var model = _mapper.Map<List<SetView>>(listEntity);
			RolSetView view = new RolSetView(model);

			return view;
		}

	}
}
