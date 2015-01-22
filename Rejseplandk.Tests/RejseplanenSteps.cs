using TechTalk.SpecFlow;

namespace Rejseplandk.Tests
{
    [Binding]
    public class RejseplanenSteps
    {
        private string _from;
        private string _to;

        [Given(@"I enter from: '(.*)'")]
        public void GivenIEnterFrom(string from)
        {
            _from = from;
        }

        [Given(@"I enter to: '(.*)'")]
        public void GivenIEnterTo(string to)
        {
            _to = to;
        }

        [When(@"I Search")]
        public void WhenISearch()
        {
            ScenarioContext.Current.Get<Driver>().Search(_from, _to);
        }


        [Then(@"I get at least (.*) travelplan")]
        public void ThenIGetAtLeastTravelplan(int p0)
        {
            ScenarioContext.Current.Get<Driver>().ContainsSearchResult(p0);
        }


    }
}