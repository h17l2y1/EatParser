using EatParser.ViewModels.Rol;
using System.Threading.Tasks;

namespace EatParser.Services.Services.Interfaces
{
	public interface IRolService
	{
		Task<GetAllRolView> GetAllSetsAsync();
	}
}
