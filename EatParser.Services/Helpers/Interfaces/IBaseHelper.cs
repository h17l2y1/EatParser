using AngleSharp.Dom;
using EatParser.Entities.Entities;
using EatParser.Services.Models;

namespace EatParser.Services.Helpers.Interfaces
{
	public interface IBaseHelper
	{
		T CreatProduct<T>(string name, string desc, int? weight, int? count, int? price, string fullImg, int type) where T : Product;

		int? StringToInt(string str);

		int[] StringToIntArray(string str);

		TempSet CreateTempSet(string str);

		string GetData(IElement iElement, string selector);

		string GetData(IElement iElement, string selector, string attribute);
	}
}
