using EatParser.Entities.Entities;
using EatParser.ViewModels;
using EatParser.ViewModels.Account.Request;

namespace EatParser.Services.Config
{
	public class MapperProfile : AutoMapper.Profile
	{
		public MapperProfile()
		{

			CreateMap<Rol, SetView>();


			CreateMap<SignUpAccountView, User>()
				.ForMember(from => from.UserName, to => to.MapFrom(source => source.Login))
				.ForMember(from => from.Password, to => to.MapFrom(source => source.Password));

			CreateMap<LoginAccountView, User>()
				.ForMember(from => from.UserName, to => to.MapFrom(source => source.Login))
				.ForMember(from => from.Password, to => to.MapFrom(source => source.Password));

		}
	}
}

