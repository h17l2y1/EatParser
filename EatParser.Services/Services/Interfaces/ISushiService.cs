using EatParser.ViewModels;
using System.Threading.Tasks;

namespace EatParser.Services.Services.Interfaces
{
	public interface ISushiService
	{
		Task<SushiSetView> GetYaposhkaSets(string str);

		Task<SushiSetView> GetMafiaSets(string str);

	}
}
