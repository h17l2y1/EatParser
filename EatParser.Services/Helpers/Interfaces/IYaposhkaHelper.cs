using AngleSharp.Dom;
using System.Collections.Generic;

namespace EatParser.Services.Helpers.Interfaces
{
	public interface IYaposhkaHelper
	{
		List<string> Parse(IDocument document);

		List<string> Waight(IDocument document);

		List<string> Count(IDocument document);
	}
}
