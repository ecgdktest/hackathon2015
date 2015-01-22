using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Rejseplandk.Tests
{
    [Binding]
    public class RejseplanenSteps
    {
        private static Driver Driver
        {
            get { return ScenarioContext.Current.Get<Driver>(); }
        }

        [Given(@"I am on the frontpage")]
        public void GivenIAmOnTheFrontpage()
        {
            Driver.GotoFrontPage();
        }


        [Given(@"I enter from: '(.*)'")]
        public void GivenIEnterFrom(string from)
        {
            Driver.Search.From = from;
        }

        [Given(@"I enter to: '(.*)'")]
        public void GivenIEnterTo(string to)
        {
            Driver.Search.To = to;
        }

        [When(@"I Search")]
        public void WhenISearch()
        {
            Driver.Search.Search();
        }

        [When(@"I expand the Searchbar section")]
        public void WhenIExpandTheSearchbarSection()
        {
            Driver.Search.Expand();
        }

        [Given(@"I pick a date '(.*)'")]
        public void GivenIPickADate(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I enter the time:\t'(.*)'")]
        public void WhenIEnterTheTime(string p0)
        {
        }

        [Given(@"I choose traveltype '(.*)'")]
        public void GivenIChooseTraveltype(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I see the Searchbar")]
        public void ThenISeeTheSearchbar()
        {
            Driver.Search.SearchBarIsVisible();
        }

        [Given(@"I pick return '(.*)'")]
        public void GivenIPickReturn(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I see search results")]
        public void ThenISeeSearchResults()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"take a screenshoot")]
        public void ThenTakeAScreenshoot()
        {
            ScenarioContext.Current.Pending();
        }


        [Then(@"I get at least (.*) travelplan")]
        public void ThenIGetAtLeastTravelplan(int p0)
        {
            ScenarioContext.Current.Get<Driver>().ContainsSearchResult(p0);
        }

        [Given(@"I fill search: '(.*)' and '(.*)'")]
        public void GivenIFillSearchAnd(string from, string to)
        {
            var froms = locations[@from];
            Driver.Search.From = froms.ElementAt(rand.Next(froms.Length));
            var tos = locations[@from];
            Driver.Search.From = tos.ElementAt(rand.Next(tos.Length));
        }
        private Random rand = new Random();
        private IDictionary<string, string[]> locations = new Dictionary<string, string[]> {{"POI", new []{"Tivoli", "Havefruen"}}, {"Telefon nr", new []{"51515151", "12341234"}},{"Street", new []{"Axel kiers vej 11","Aarhus Vej"}}};

    }
}