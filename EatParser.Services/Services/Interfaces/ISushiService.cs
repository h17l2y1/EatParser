using EatParser.ViewModels.Sushi;
using System.Threading.Tasks;

namespace EatParser.Services.Services.Interfaces
{
	public interface ISushiService
	{
		Task<GetAllSushiView> GetAllSetsAsync();
	}
}
