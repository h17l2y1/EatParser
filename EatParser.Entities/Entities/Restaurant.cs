using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatParser.Entities.Entities
{
	public class Restaurant : BaseEntity
	{
		public string Name { get; set; }

		[NotMapped]
		[Computed]
		public virtual ICollection<Rol> RolSets { get; set; }
	}
}
