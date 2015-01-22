﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace Rejseplandk.Tests
{
    public interface Driver : IDisposable{
        void ContainsSearchResult(int p0);
        void ResetDriver();
        void GotoFrontPage();
        ISearchBox Search { get; }
    }

    public class SeleniumBase
    {
        private readonly RemoteWebDriver _driver;

        public SeleniumBase(RemoteWebDriver driver)
        {
            _driver = driver;
        }

        protected void SetText(By byId, string value)
        {
            _driver.FindElement(byId).SendKeys(value);
        }

        protected string GetText(By byId)
        {
            return _driver.FindElement(byId).Text;
        }

        protected void Click(By search)
        {
            _driver.FindElement(search).Click();
        }

        public bool ExistsAndVisibleElement(By by, int timeoutInSeconds = 5)
        {
            bool flag = false;
            try
            {
                if (timeoutInSeconds > 0)
                {
                    IWebElement webElement = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(drv => drv.FindElement(@by));
                    if (webElement != null && webElement.Displayed)
                        flag = true;
                }
                IWebElement element = _driver.FindElement(@by);
                flag = element != null && element.Displayed;
            }
            catch (Exception ex)
            {
            }
            return flag;
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
}