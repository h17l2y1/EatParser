using System;
using System.ComponentModel.DataAnnotations;

namespace EatParser.Entities.Entities.Interface
{
	public interface IBaseEntity
	{
		[Key]
		int Id { get; set; }
		DateTime CreationDate { get; set; }
	}
}
