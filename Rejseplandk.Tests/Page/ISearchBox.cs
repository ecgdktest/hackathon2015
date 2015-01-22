namespace Rejseplandk.Tests
{
    public interface ISearchBox
    {
        string To { get; set; }
        string From { get; set; }
        void Search();
        void Expand();

    }
}