using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Xml.Linq;
using NUnit.Framework;

namespace Rejseplandk.Tests
{
    public class Rest : Driver
    {
        private RestSearchBox _searchBox;

        public void ContainsSearchResult(int p0)
        {
            Assert.That(_searchBox.Trips.ToArray(), Has.Length.AtLeast(p0));
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
        private IEnumerable<XElement> trips;
        public string To { get; set; }
        public string From { get; set; }

        public IEnumerable<XElement> Trips
        {
            get { return trips; }
            private set { trips = value; }
        }

        public void Search()
        {
            using (var client = new HttpClient())
            {

                var from = AsJson(client, "/location?input=" + From);
                var to = AsJson(client, "/location?input=" + To);

            var nameValueCollection = HttpUtility.ParseQueryString("");

            nameValueCollection["originCoordName"] = (string)from.Attribute("name");
            nameValueCollection["originCoordX"] = (string)from.Attribute("x");
            nameValueCollection["originCoordY"] = (string)from.Attribute("y");
            nameValueCollection["destCoordName"] = (string)to.Attribute("name");
            nameValueCollection["destCoordX"] = (string)to.Attribute("x");
            nameValueCollection["destCoordY"] = (string)to.Attribute("y");

            string url = "http://hackathon.rejseplanen.dk/bin/rest.exe/trip?" + nameValueCollection;
            Trips = XElement.Parse(client.GetAsync(url).Result.Content.ReadAsStringAsync().Result).Descendants("Trip");
            }
        }

        public void Expand()
        {
        }
        private XElement AsJson(HttpClient client, string s)
        {
            var xElement =
                XElement.Parse(
                    client.GetAsync("http://hackathon.rejseplanen.dk/bin/rest.exe" + s)
                        .Result.Content.ReadAsStringAsync()
                        .Result)
                    .Descendants().First(x => x.Name.LocalName.Contains("Location"));
            return xElement;
        }
    }
}