using NUnit.Framework;
using OpenQA.Selenium;

namespace Rejseplandk.Tests
{
    public class PublicWeb<TDriverFactory>: SeleniumBaseClass<TDriverFactory>, Driver where TDriverFactory : IDriverFactory
    {
        public void ContainsSearchResult(int p0)
        {
            var readOnlyCollection = Driver.FindElements(By.CssSelector("[id^='ovConRowOUTWARDC']"));
            Assert.That(readOnlyCollection, Has.Count.AtLeast(p0));
        }

        public void GotoFrontPage()
        {
            Driver.Navigate().GoToUrl("http://hackathon.rejseplanen.dk");
            Driver.SwitchTo().Frame("rejseplanen");
        }

        public ISearchBox Search
        {
            get
            {
                return new SearchBox(Driver, By.Id("hafasfrom"), By.Id("hafasto"), By.Name("start"));
            }
        }
    }
}