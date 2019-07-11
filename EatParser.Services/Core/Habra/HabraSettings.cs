
namespace Parser.Core.Habra
{
    class HabraSettings : IHabraSettings
    {
        public HabraSettings(string site, string prefix, int start, int end)
        {
			BaseUrl = site;
			Prefix = prefix;
			StartPoint = start;
            EndPoint = end;
        }

		public HabraSettings(int start, int end)
		{
			StartPoint = start;
			EndPoint = end;
		}

		public string BaseUrl { get; set; } = "https://habrahabr.ru";

        public string Prefix { get; set; } = "page{CurrentId}";

        public int StartPoint { get; set; }

        public int EndPoint { get; set; }
    }
}
