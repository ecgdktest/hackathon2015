using System.Net.Http;

namespace Rejseplandk.Tests
{
    public class Rest : Driver
    {
        private RestSearchBox _searchBox;

        public void ContainsSearchResult(int p0)
        {
        }

        public void Dispose()
        {
            ResetDriver();
        }

        public void ResetDriver()
        {
        }

        public void GotoFrontPage()
        {
            _searchBox = new RestSearchBox();
        }

        public ISearchBox Search
        {
            get { return _searchBox; }
        }
    }

    public class RestSearchBox : ISearchBox
    {
        public string To { get; set; }
        public string From { get; set; }
        public void Search()
        {
            string url = "http://hackathon.rejseplanen.dk/bin/rest.exe//trip?originCoordName=" + From + "&destCoordName=" + To;
            using (var client = new HttpClient())
            {
                var httpContent = client.GetAsync(url).Result.Content;
            }
        }

        public void Expand()
        {
        }
    }
}