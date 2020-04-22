using AngleSharp.Dom;
using EatParser.Entities.Entities;
using System.Collections.Generic;

namespace EatParser.Services.Helpers.Interfaces
{
	public interface IMafiaHelper : IBaseHelper
	{
		IEnumerable<T> Parse<T>(IDocument document, string restaurantId) where T : Product;
	}
}
