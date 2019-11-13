using EatParser.Entities.Entities.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace EatParser.Entities.Entities
{
	public class BaseEntity : IBaseEntity
	{
		[Key]
		public int Id { get; set; }

		public DateTime CreationDate { get; set; }

		public BaseEntity()
		{
			CreationDate = DateTime.UtcNow;
		}
	}
}
