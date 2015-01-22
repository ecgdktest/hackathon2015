using OpenQA.Selenium;

namespace Rejseplandk.Tests
{
    public class MWeb<T> : SeleniumBaseClass<T>, Driver where T : IDriverFactory
    {
        public void GotoFrontPage()
        {
            Driver.Navigate().GoToUrl("http://m-hackathon.rejseplanen.dk");
        }

        public ISearchBox Search
        {
            get
            {
                return new SearchBox(Driver, By.Id("tpQuery_from"), By.Id("tpQuery_to"), By.Id("tpQueryDate"), By.Id("tpQuery_time"), By.Name("tpSubmitButton"), By.ClassName("icon-inner"));
            }
        }

        public void ContainsSearchResult(int p0)
        {
        }
    }
}