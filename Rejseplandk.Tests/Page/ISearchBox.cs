namespace Rejseplandk.Tests
{
    public interface ISearchBox
    {
        string To { get; set; }
        string From { get; set; }
        string Date { get; set; }
        string Time { get; set; }
        
        void Search();
        void ShowSearchBar();

        void SearchBarIsVisible();
    }
}