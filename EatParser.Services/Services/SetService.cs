using AutoMapper;
using EatParser.DataAccess.Repositories.Interfaces;
using EatParser.Services.Services.Interfaces;
using EatParser.ViewModels.Set;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Services
{
	public class SetService : ISetService
	{
		private readonly IMapper _mapper;
		private readonly ISetRepository _setRepository;

		public SetService(IMapper mapper, ISetRepository setRepository)
		{
			_mapper = mapper;
			_setRepository = setRepository;
		}

		public async Task<GetAllSetView> GetAllSetsAsync()
		{
			var listEntity = await _setRepository.GetAll();
			var model = _mapper.Map<List<GetAllSetViewItem>>(listEntity);
			GetAllSetView view = new GetAllSetView(model);

			return view;
		}
	}
}
