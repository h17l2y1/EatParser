using EatParser.Entities.Entities;
using EatParser.ViewModels;

namespace EatParser.Services.Config
{
	public class MapperProfile : AutoMapper.Profile
	{
		public MapperProfile()
		{
			CreateMap<SushiSet, SetView>().ReverseMap();

		}
	}
}

