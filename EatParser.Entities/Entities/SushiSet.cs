namespace EatParser.Entities.Entities
{
	public class SushiSet : BaseEntity
	{
		public string Name { get; set; }

		public int Weight { get; set; }

		public int Count { get; set; }

		public int Price { get; set; }

		public string Image { get; set; }
	}
}
