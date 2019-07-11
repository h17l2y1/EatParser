using AngleSharp.Html.Dom;
using System.Collections.Generic;

namespace Parser.Core
{
    public interface IHabraParser
    {
		List<string> Parse(IHtmlDocument document);
    }
}
