using AngleSharp.Html.Dom;
using System.Threading.Tasks;

namespace EatParser.Services.Helpers.Interfaces
{
	public interface IHtmlLoaderHelper
	{
		Task<IHtmlDocument> GetPageSource(string url);
	}
}
