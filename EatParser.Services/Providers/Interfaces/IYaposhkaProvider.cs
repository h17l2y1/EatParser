﻿using EatParser.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Providers.Interfaces
{
	public interface IYaposhkaProvider : IBaseProvider
	{
		Task<IEnumerable<Set>> GetSets();

		Task<IEnumerable<Rol>> GetRols();

		Task<IEnumerable<Sushi>> GetSushi();

		Task<IEnumerable<Pizza>> GetPizza();
	}
}
