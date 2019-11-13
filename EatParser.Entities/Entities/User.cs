using EatParser.Entities.Entities.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatParser.Entities.Entities
{
	[Table("AspNetUsers")]
	public class User : IdentityUser<int>, IBaseEntity
	{
		public string Password { get; set; }
		public DateTime CreationDate { get; set; }

		public User()
		{
			CreationDate = DateTime.UtcNow;
		}
	}
}
