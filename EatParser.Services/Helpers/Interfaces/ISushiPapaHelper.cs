﻿using AngleSharp.Dom;
using EatParser.Entities.Entities;
using System.Collections.Generic;

namespace EatParser.Services.Helpers.Interfaces
{
	public interface ISushiPapaHelper : IBaseHelper
	{
		List<T> Parse<T>(IDocument document) where T : Product;
	}
}
