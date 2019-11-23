using EatParser.ViewModels;
using System.Threading.Tasks;

namespace EatParser.Services.Services.Interfaces
{
	public interface IRolSetService
	{
		Task<RolSetView> GetAllSetsAsync();

		Task<RolSetView> GetYaposhkaSets();

		Task<RolSetView> GetMafiaSets();
	}
}
