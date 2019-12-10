using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatParser.Entities.Entities
{
	public class Product : BaseEntity
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public int? Weight { get; set; }

		public int? Count { get; set; }

		public int? Price { get; set; }

		public string Image { get; set; }

		public int RestaurantId { get; set; }

		[ForeignKey("RestaurantId")]
		[NotMapped]
		[Computed]
		public virtual Restaurant Restaurant { get; set; }
	}
}
