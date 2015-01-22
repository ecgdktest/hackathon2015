using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Rejseplandk.Tests
{
    public interface IDriverFactory
    {
        RemoteWebDriver Create();
    }
    class ChromeDriverFactory : IDriverFactory
    {
        public RemoteWebDriver Create()
        {
            var driverPath = @"C:\Users\strudsomahon\Downloads\chromedriver_win32";
            return new ChromeDriver(driverPath);
        }

    }
}