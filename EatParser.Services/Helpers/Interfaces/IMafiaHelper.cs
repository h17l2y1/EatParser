using AngleSharp.Dom;
using EatParser.Entities.Entities;
using System.Collections.Generic;

namespace EatParser.Services.Helpers.Interfaces
{
	public interface IMafiaHelper
	{
		List<RolSet> Parse(IDocument document);

	}
}
