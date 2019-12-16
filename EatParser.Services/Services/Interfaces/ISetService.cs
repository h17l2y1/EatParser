using EatParser.ViewModels;
using System.Threading.Tasks;

namespace EatParser.Services.Services.Interfaces
{
	public interface ISetService
	{
		Task<GetAllRolView> GetAllSetsAsync();

	}
}
