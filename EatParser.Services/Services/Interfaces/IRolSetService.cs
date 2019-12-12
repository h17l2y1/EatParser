using EatParser.ViewModels;
using System.Threading.Tasks;

namespace EatParser.Services.Services.Interfaces
{
	public interface IRolService
	{
		Task<GetAllRolView> GetAllSetsAsync();

	}
}
