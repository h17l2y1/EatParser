using EatParser.ViewModels;
using System.Threading.Tasks;

namespace EatParser.Services.Services.Interfaces
{
	public interface IRolSetService
	{
		Task<RolSetView> GetYaposhkaSets(string str);

		Task<RolSetView> GetMafiaSets(string str);
	}
}
