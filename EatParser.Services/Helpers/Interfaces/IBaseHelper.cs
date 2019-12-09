using EatParser.Entities.Entities;

namespace EatParser.Services.Helpers.Interfaces
{
	public interface IBaseHelper
	{
		T CreatObject<T>(string name, string desc, int weight, int? count, int price, string fullImg, int type) where T : Product;

		int StringToInt(string str);
	}
}
