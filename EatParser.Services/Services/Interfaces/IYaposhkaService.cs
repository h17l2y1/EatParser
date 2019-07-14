using EatParser.ViewModels;
using System.Threading.Tasks;

namespace EatParser.Services.Services.Interfaces
{
	public interface IYaposhkaService
	{
		Task<SushiSetView> GetYaposhkaSets(string str);


	}
}
