namespace Vega.Extentions
{
    public interface IQueryObject
    {
        string SortBy { get; set; }
        bool IsSortAssending { get; set; }
        int Page { get; set; }
        byte PageSize { get; set; }
    }
}