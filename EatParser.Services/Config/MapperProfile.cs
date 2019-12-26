using EatParser.Entities.Entities;
using EatParser.ViewModels.Account.Request;
using EatParser.ViewModels.Pizza;
using EatParser.ViewModels.Rol;
using EatParser.ViewModels.Set;
using EatParser.ViewModels.Sushi;

namespace EatParser.Services.Config
{
	public class MapperProfile : AutoMapper.Profile
	{
		public MapperProfile()
		{

			CreateMap<Rol, GetAllRolViewItem>();
			CreateMap<Set, GetAllSetViewItem>();
			CreateMap<Sushi, GetAllSushiViewItem>();
			CreateMap<Pizza, GetAllPizzaViewItem>();


			CreateMap<SignUpAccountView, User>()
				.ForMember(from => from.UserName, to => to.MapFrom(source => source.Login))
				.ForMember(from => from.Password, to => to.MapFrom(source => source.Password));

			CreateMap<LoginAccountView, User>()
				.ForMember(from => from.UserName, to => to.MapFrom(source => source.Login))
				.ForMember(from => from.Password, to => to.MapFrom(source => source.Password));

		}
	}
}

