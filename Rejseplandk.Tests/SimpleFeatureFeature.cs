using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace Rejseplandk.Tests
{
    public interface Driver : IDisposable{
        void Search(string @from, string to);
        void ContainsSearchResult(int p0);
        void ResetDriver();
    }

    class DriverImpl1<TWebDriver> : Driver where TWebDriver : RemoteWebDriver
    {
        private Lazy<TWebDriver> browserFac;

        public DriverImpl1()
        {
            ResetDriver();
        }

        public static bool ExistsAndVisibleElement(IWebDriver driver, By by, int timeoutInSeconds = 5)
        {
            bool flag = false;
            try
            {
                if (timeoutInSeconds > 0)
                {
                    IWebElement webElement = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(drv => drv.FindElement(@by));
                    if (webElement != null && webElement.Displayed)
                        flag = true;
                }
                IWebElement element = driver.FindElement(by);
                flag = element != null && element.Displayed;
            }
            catch (Exception ex)
            {
            }
            return flag;
        }
        private string url = "http://hackathon.rejseplanen.dk";
        public void Search(string @from, string to)
        {
            Driver.Navigate().GoToUrl(url);
            Driver.SwitchTo().Frame("rejseplanen");
            Driver.FindElement(By.Id("hafasfrom")).SendKeys(@from);
            Driver.FindElement(By.Id("hafasto")).SendKeys(@to);
            Driver.FindElementByName("start").Click();
        }

        private RemoteWebDriver Driver
        {
            get { return browserFac.Value; }
        }

        public void ContainsSearchResult(int p0)
        {
            var readOnlyCollection = Driver.FindElements(By.CssSelector("[id^='ovConRowOUTWARDC']"));
            Assert.That(readOnlyCollection, Has.Count.AtLeast(p0));
        }

        public void Dispose()
        {
            ResetDriver();
        }

        public void ResetDriver()
        {
            if (browserFac != null && browserFac.IsValueCreated)
            {
                browserFac.Value.Close();
                browserFac.Value.Dispose();
            }
            var driverPath = @"C:\Work\ECG.Selenium\ECG.Selenium.Framework\Executables\";
            browserFac = new Lazy<TWebDriver>(() => (TWebDriver) Activator.CreateInstance(typeof(TWebDriver), new []{driverPath}));
        }
    }

    abstract partial class SimpleFeatureFeature { }

    [TestFixture(typeof (DriverImpl1<ChromeDriver>))]
    public class SimpleFeatureLa<T> : RejseplanenFeature where T : Driver
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