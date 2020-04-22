using AngleSharp.Dom;
using EatParser.Entities.Entities;
using System.Collections.Generic;

namespace EatParser.Services.Helpers.Interfaces
{
	public interface IYaposhkaHelper : IBaseHelper
	{
		IEnumerable<T> Parse<T>(IDocument document, string restourantId) where T : Product;
	}
}
