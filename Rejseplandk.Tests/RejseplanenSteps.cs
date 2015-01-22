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
        public void GivenIPickADate(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I choose traveltype '(.*)'")]
        public void GivenIChooseTraveltype(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I pick return '(.*)'")]
        public void GivenIPickReturn(string p0)
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

        private static Driver Driver
        {
            get { return ScenarioContext.Current.Get<Driver>(); }
        }
    }
}