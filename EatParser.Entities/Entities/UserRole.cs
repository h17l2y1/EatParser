using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatParser.Entities.Entities
{
	[Table("AspNetRoles")]
	public class UserRole : IdentityRole<string>
	{
		public UserRole()
		{
		}

		public UserRole(string name) : base(name)
		{
		}
	}
}
