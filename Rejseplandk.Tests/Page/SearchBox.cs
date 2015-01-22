using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Rejseplandk.Tests
{
    public class SearchBox : SeleniumBase, ISearchBox
    {
        private readonly By _fromField;
        private readonly By _byId;
        private readonly By _search;

        public SearchBox(RemoteWebDriver driver, By fromField, By toField, By startButton) : base(driver)
        {
            _byId = fromField;
            _fromField = toField;
            _search = startButton;
        }

        public string To
        {
            get { return GetText(_fromField); }
            set { SetText(_fromField, value); }
        }

        public string From
        {
            get { return GetText(_byId); }
            set { SetText(_byId, value); }
        }

        public void Search()
        {
            Click(_search);
        }
    }
}