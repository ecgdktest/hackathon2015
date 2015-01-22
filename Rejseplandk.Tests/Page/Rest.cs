using System.Collections.Generic;
using System.Collections.Specialized;
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
        public IEnumerable<XElement> Trips { get; private set; }
        public string To { get; set; }
        public string From { get; set; }

        public void Search()
        {
            using (var client = new HttpClient())
            {
                XElement from = AsJson(client, "/location?input=" + From);
                XElement to = AsJson(client, "/location?input=" + To);

                NameValueCollection nameValueCollection = HttpUtility.ParseQueryString("");

                nameValueCollection["originCoordName"] = (string) from.Attribute("name");
                nameValueCollection["originCoordX"] = (string) from.Attribute("x");
                nameValueCollection["originCoordY"] = (string) from.Attribute("y");
                nameValueCollection["destCoordName"] = (string) to.Attribute("name");
                nameValueCollection["destCoordX"] = (string) to.Attribute("x");
                nameValueCollection["destCoordY"] = (string) to.Attribute("y");

                string url = "http://hackathon.rejseplanen.dk/bin/rest.exe/trip?" + nameValueCollection;
                Trips =
                    XElement.Parse(client.GetAsync(url).Result.Content.ReadAsStringAsync().Result).Descendants("Trip");
            }
        }

        public void ShowSearchBar()
        {
        }

        public void SearchBarIsVisible()
        {
        }

        private XElement AsJson(HttpClient client, string s)
        {
            XElement xElement =
                XElement.Parse(
                    client.GetAsync("http://hackathon.rejseplanen.dk/bin/rest.exe" + s)
                        .Result.Content.ReadAsStringAsync()
                        .Result)
                    .Descendants().First(x => x.Name.LocalName.Contains("Location"));
            return xElement;
        }
    }
}