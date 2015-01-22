using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Rejseplandk.Tests
{
    public class SearchBox : SeleniumBase, ISearchBox
    {
        private readonly By _fromField;
        private readonly By _toField;
        private readonly By _dateField;
        private readonly By _timeField;
        private readonly By _search;
        private readonly By _expand;


        public SearchBox(RemoteWebDriver driver, By fromField, By toField, By dateField, By timeField, By startButton,
            By expand) : base(driver)
        {
            _toField = fromField;
            _fromField = toField;
            _dateField = _dateField;
            _timeField = _timeField;
            _search = startButton;
            _expand = expand;
        }

        public string To
        {
            get { return GetText(_toField); }
            set { SetText(_toField, value); }
        }

        public string From
        {
            get { return GetText(_fromField); }
            set { SetText(_fromField, value); }
        }

        public string Date
        {
            get { return GetText(_dateField); }
            set { SetText(_dateField, value); }
        }

        public string Time
        {
            get { return GetText(_timeField); }
            set { SetText(_timeField, value); }
        }

        public void Search()
        {
            Click(_search);
        }

        public void Expand()
        {
            Click(_expand);
        }

        public void SearchBarIsVisible()
        {
            Assert.True(this.ExistsAndVisibleElement(_fromField));
        }
    }
}
