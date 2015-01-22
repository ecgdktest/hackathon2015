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
            FindElement(byId).SendKeys(value);
        }

        private IWebElement FindElement(By byId)
        {
            try
            {
                return _driver.FindElement(byId);
            }
            catch (NoSuchElementException ex)
            {
                throw new Exception(string.Format("Could not find:{0}", byId), ex);
            }
        }

        protected string GetText(By byId)
        {
            return FindElement(byId).Text;
        }

        protected void Click(By search)
        {
            FindElement(search).Click();
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
            catch (Exception)
            {
            }
            return flag;
        }


    }

    abstract partial class RejseplanenFeature : AllDrivers { }
    abstract partial class SearchingFeature : AllDrivers { }
    abstract partial class ResultsFeature : AllDrivers { }
    abstract partial class SearchScenariosFeature : AllDrivers { }
    abstract partial class HelpTheUserInputDataOnOurSiteFeature : AllDrivers { }


    [TestFixture(typeof(PublicWeb<ChromeDriverFactory>))]
    [TestFixture(typeof(PublicWeb<IEDriverFactory>))]
    [TestFixture(typeof(PublicWeb<RemoteDriverFactory>))]
    [TestFixture(typeof(MWeb<RemoteDriverFactory>))]
    [TestFixture(typeof(MWeb<ChromeDriverFactory>))]
    [TestFixture(typeof(MWeb<IEDriverFactory>))]
    [TestFixture(typeof(Rest))]
    public class AllDrivers
    {
    }

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
    public class SearchingFeature<T> : SearchingFeature where T : Driver
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
    public class ResultsFeature<T> : ResultsFeature where T : Driver
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
    public class SearchScenariosFeature<T> : SearchScenariosFeature where T : Driver
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
    public class HelpTheUserInputDataOnOurSiteFeature<T> : HelpTheUserInputDataOnOurSiteFeature where T : Driver
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