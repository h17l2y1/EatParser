﻿using AngleSharp.Dom;
using EatParser.Entities.Entities;
using EatParser.Services.Helpers.Interfaces;
using EatParser.Services.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace EatParser.Services.Helpers
{
	public class BaseHelper : IBaseHelper
	{
		protected IHtmlCollection<IElement> _divs;

		public T CreatProduct<T>(string name, string desc, int weight, int? count, int price, string fullImg, int type) where T : Product
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

		public int[] StringToIntArray(string str)
		{
			string productString = Regex.Replace(str, @"[^0-9$-.;:/]", "");

			if (!int.TryParse(new string(productString[0], 1), out _))
			{
				productString = productString.Substring(1, productString.Length - 1);
			}
			if (!int.TryParse(new string(productString[productString.Length - 1], 1), out _))
			{
				productString = productString.Substring(0, productString.Length - 1);
			}

			string ch = Regex.Replace(productString, @"[0-9]", "");

			int[] setData = productString.Split(ch).Select(x => Convert.ToInt32(x)).ToArray();

			return setData;
		}

		public TempSet CreateTempSet(string str)
		{
			int[] setData = StringToIntArray(str);

			var set = new TempSet();

			if (setData.Length < 2)
			{
				set.Weight = setData[0];
			}
			if (setData.Length > 1)
			{
				if (setData[0] > setData[1])
				{
					set.Count = setData[1];
					set.Weight = setData[0];
					return set;
				}
				set.Count = setData[0];
				set.Weight = setData[1];
			}

			return set;
		}

		public string GetData(IElement iElement, string selector)
		{
			IElement currentIElement = iElement.QuerySelector(selector);
			if (currentIElement == null)
			{
				return null;
			}

			string result = currentIElement.Text();
			result = result.Replace("\n", " ").Trim();
			if (result.Length < 1)
			{
				return null;
			}
			return result;
		}

		public string GetData(IElement iElement, string selector, string attribute)
		{
			IElement currentIElement = iElement.QuerySelector(selector);
			if (currentIElement == null)
			{
				return null;
			}
			string result = currentIElement.GetAttribute(attribute);
			result = result.Replace("\n", " ").Trim();
			if (result.Length < 1)
			{
				return null;
			}
			return result;
		}
	}
}
