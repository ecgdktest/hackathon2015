using TechTalk.SpecFlow;

namespace Rejseplandk.Tests
{
    [Binding]
    public class RejseplanenSteps
    {
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

   

        [Given(@"I pick a date '(.*)'")]
        public void GivenIPickADate(string date)
        {
            Driver.Search.Date = date;
        }

        [When(@"I enter the time:\t'(.*)'")]
        public void WhenIEnterTheTime(string time)
        {
            Driver.Search.Time = time;
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
            Driver.Search.ShowSearchBar();
        }

        [Then(@"I see search results")]
        public void ThenISeeSearchResults()
        {
            ScenarioContext.Current.Get<Driver>().ContainsSearchResult(3);
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

        private static Driver Driver
        {
            get { return ScenarioContext.Current.Get<Driver>(); }
        }
    }
}