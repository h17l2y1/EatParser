using AngleSharp.Dom;
using EatParser.Entities.Entities;
using EatParser.Services.Helpers.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace EatParser.Services.Helpers
{
	public class BaseHelper : IBaseHelper
	{
		protected IHtmlCollection<IElement> _divs;

		public T CreatObject<T>(string name, string desc, int weight, int? count, int price, string fullImg, int type) where T : Product
		{
			T genericObject = (T)Activator.CreateInstance(typeof(T));

			genericObject.Name = name;
			genericObject.Description = desc;
			genericObject.Weight = weight;
			genericObject.Count = count;
			genericObject.Price = price;
			genericObject.Image = fullImg;
			genericObject.RestaurantId = type;

			return genericObject;
		}

		public int StringToInt(string str)
		{
			str = Regex.Replace(str, "[^0-9]", "");
			var number = Int32.Parse(str);
			return number;
		}
	}
}
