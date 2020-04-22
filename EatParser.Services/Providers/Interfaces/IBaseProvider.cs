using AngleSharp.Dom;
using System.Threading.Tasks;

namespace EatParser.Services.Providers.Interfaces
{
	public interface IBaseProvider
	{
		Task<IDocument> GetDocument(string url);
	}
}
