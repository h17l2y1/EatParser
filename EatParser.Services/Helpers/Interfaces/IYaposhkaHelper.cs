using AngleSharp.Dom;
using EatParser.Entities.Entities;
using System.Collections.Generic;

namespace EatParser.Services.Helpers.Interfaces
{
	public interface IYaposhkaHelper
	{
		List<RolSet> Parse(IDocument document);
	}
}
