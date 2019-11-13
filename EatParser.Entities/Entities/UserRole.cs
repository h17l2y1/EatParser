﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatParser.Entities.Entities
{
	[Table("AspNetRoles")]
	public class UserRole : IdentityRole<int>
	{
		public UserRole()
		{
		}

		public UserRole(string name) : base(name)
		{
		}
	}
}
