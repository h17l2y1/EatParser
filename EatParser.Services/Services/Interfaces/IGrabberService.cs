using System.Threading.Tasks;

namespace EatParser.Services.Services.Interfaces
{
	public interface IGrabberService
	{
		Task GrabbAllRestaurant();

		Task GrabbYaposhka();

		Task GrabbMafia();

		Task GrabbSushiPapa();
	}
}
