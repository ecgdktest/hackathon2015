using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Rejseplandk.Tests
{
    public abstract class SeleniumBaseClass<TDriverFactory> where TDriverFactory : IDriverFactory
    {
        private readonly TDriverFactory _driverFactory;
        private Lazy<RemoteWebDriver> _browserFac;

        protected SeleniumBaseClass()
        {
            _driverFactory = Activator.CreateInstance<TDriverFactory>();
            ResetDriver();
        }

        protected RemoteWebDriver Driver
        {
            get { return _browserFac.Value; }
        }

        public bool ExistsAndVisibleElement(IWebDriver driver, By by, int timeoutInSeconds = 5)
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
                IWebElement element = driver.FindElement(@by);
                flag = element != null && element.Displayed;
            }
            catch (Exception ex)
            {
            }
            return flag;
        }

        public void Dispose()
        {
            ResetDriver();
        }

        public void ResetDriver()
        {
            if (_browserFac != null && _browserFac.IsValueCreated)
            {
                _browserFac.Value.Close();
                _browserFac.Value.Dispose();
            }
            _browserFac = new Lazy<RemoteWebDriver>(() => _driverFactory.Create());
        }

    }
}