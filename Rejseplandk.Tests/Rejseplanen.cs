using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Rejseplandk.Tests
{
    public interface Driver : IDisposable{
        void Search(string @from, string to);
        void ContainsSearchResult(int p0);
        void ResetDriver();
    }

    public class PublicWeb<TDriverFactory>: SeleniumBaseClass<TDriverFactory>, Driver where TDriverFactory : IDriverFactory
    {
        private string url = "http://hackathon.rejseplanen.dk";

        public void Search(string @from, string to)
        {
            Driver.Navigate().GoToUrl(url);
            Driver.SwitchTo().Frame("rejseplanen");
            Driver.FindElement(By.Id("hafasfrom")).SendKeys(@from);
            Driver.FindElement(By.Id("hafasto")).SendKeys(@to);
            Driver.FindElementByName("start").Click();
        }

        public void ContainsSearchResult(int p0)
        {
            var readOnlyCollection = Driver.FindElements(By.CssSelector("[id^='ovConRowOUTWARDC']"));
            Assert.That(readOnlyCollection, Has.Count.AtLeast(p0));
        }

    }

    public class MWeb<T> : SeleniumBaseClass<T>, Driver where T : IDriverFactory
    {
        private string url = "http://m-hackathon.rejseplanen.dk";

        public void Search(string @from, string to)
        {
            Driver.Navigate().GoToUrl(url);
            Driver.FindElement(By.Id("tpQuery_from")).SendKeys(@from);
            Driver.FindElement(By.Id("tpQuery_to")).SendKeys(@to);
            Driver.FindElement(By.Id("tpSubmitButton")).Click();
        }

        public void ContainsSearchResult(int p0)
        {
        }
    }

    abstract partial class RejseplanenFeature { }

    [TestFixture(typeof(PublicWeb<ChromeDriverFactory>))]
    [TestFixture(typeof(MWeb<ChromeDriverFactory>))]
    [TestFixture(typeof(Rest))]
    public class RejseplanenFeature<T> : RejseplanenFeature where T : Driver
    {
        private Driver _driver;

        public override void FeatureSetup()
        {
            base.FeatureSetup();
            _driver = Activator.CreateInstance<T>();

        }

        public override void ScenarioSetup(ScenarioInfo scenarioInfo)
        {
            base.ScenarioSetup(scenarioInfo);
            ScenarioContext.Current.Set(_driver);
        }

        public override void ScenarioTearDown()
        {
            base.ScenarioTearDown();
            _driver.ResetDriver();
        }
    }

    public class Rest : Driver
    {
        public void Search(string @from, string to)
        {
        }

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
    }
}