using EatParser.ViewModels.Set;
using System.Threading.Tasks;

namespace EatParser.Services.Services.Interfaces
{
	public interface ISetService
	{
		Task<GetAllSetView> GetAllSetsAsync();
	}
}
