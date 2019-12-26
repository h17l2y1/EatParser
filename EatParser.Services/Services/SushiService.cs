using AutoMapper;
using EatParser.DataAccess.Repositories.Interfaces;
using EatParser.Services.Services.Interfaces;
using EatParser.ViewModels.Sushi;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Services
{
	public class SushiService : ISushiService
	{
		private readonly IMapper _mapper;
		private readonly ISushiRepository _sushiRepository;

		public SushiService(IMapper mapper, ISushiRepository sushiRepository)
		{
			_mapper = mapper;
			_sushiRepository = sushiRepository;
		}

		public async Task<GetAllSushiView> GetAllSetsAsync()
		{
			var listEntity = await _sushiRepository.GetAll();
			var model = _mapper.Map<List<GetAllSushiViewItem>>(listEntity);
			GetAllSushiView view = new GetAllSushiView(model);

			return view;
		}
	}
}
