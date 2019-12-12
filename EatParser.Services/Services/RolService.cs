using AutoMapper;
using EatParser.DataAccess.Repositories.Interfaces;
using EatParser.Services.Services.Interfaces;
using EatParser.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Services
{
	public class RolService : IRolService
	{
		private readonly IMapper _mapper;
		private readonly IRolRepository _roleSetRepository;

		public RolService(IMapper mapper, IRolRepository roleSetRepository)
		{
			_mapper = mapper;
			_roleSetRepository = roleSetRepository;
		}

		public async Task<GetAllRolView> GetAllSetsAsync()
		{
			var listEntity = await _roleSetRepository.GetAll();
			var model = _mapper.Map<List<ProductView>>(listEntity);
			GetAllRolView view = new GetAllRolView(model);

			return view;
		}

	}
}
