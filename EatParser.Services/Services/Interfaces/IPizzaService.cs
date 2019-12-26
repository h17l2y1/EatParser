using EatParser.ViewModels.Pizza;
using System.Threading.Tasks;

namespace EatParser.Services.Services.Interfaces
{
	public interface IPizzaService
	{
		Task<GetAllPizzaView> GetAllSetsAsync();
	}
}
