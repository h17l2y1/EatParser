using AutoMapper;
using EatParser.DataAccess.Repositories.Interfaces;
using EatParser.Services.Services.Interfaces;
using EatParser.ViewModels;
using System.Collections.Generic;
using System.Linq;
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

		public async Task<GetAllRolView> GetAllSetsAsync()
		{
			var listEntity = await _setRepository.GetAll();
			var model = _mapper.Map<List<ProductView>>(listEntity);
			GetAllRolView view = new GetAllRolView(model);

			return view;
		}

	}
}
