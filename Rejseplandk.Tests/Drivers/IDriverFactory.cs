using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace Rejseplandk.Tests
{
    public interface IDriverFactory
    {
        RemoteWebDriver Create();
    }

    public class IEDriverFactory : IDriverFactory
    {
        public RemoteWebDriver Create()
        {
            var driverPath = @"..\..\";
            return new InternetExplorerDriver(driverPath);
        }
    }

    class RemoteDriverFactory : IDriverFactory
    {
        public RemoteWebDriver Create()
        {
            return new RemoteWebDriver(new Uri("http://localhost:8080/wd/hub"), new DesiredCapabilities { IsJavaScriptEnabled = true }, TimeSpan.FromMinutes(1));
        }
    }
    class ChromeDriverFactory : IDriverFactory
    {
        public RemoteWebDriver Create()
        {
            var driverPath = @"..\..\";
            return new ChromeDriver(driverPath);
        }

    }
}