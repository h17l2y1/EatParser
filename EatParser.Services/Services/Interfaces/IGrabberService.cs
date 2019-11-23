using System.Threading.Tasks;

namespace EatParser.Services.Services.Interfaces
{
	public interface IGrabberService
	{
		Task GrabbAllRestaurant();

		Task GrabbYaposhkaSets();

		Task GrabbMafiaSets();
	}
}
