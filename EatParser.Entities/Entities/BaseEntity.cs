using Dapper.Contrib.Extensions;
using EatParser.Entities.Entities.Interface;
using System;

namespace EatParser.Entities.Entities
{
	public class BaseEntity : IBaseEntity
	{
		[Key]
		[ExplicitKey]
		public string Id { get; set; }
		public DateTime CreationDate { get; set; }

		public BaseEntity()
		{
			Id = Guid.NewGuid().ToString();
			CreationDate = DateTime.UtcNow;
		}
	}
}
