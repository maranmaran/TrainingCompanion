namespace Backend.Common
{
    public class PaginationModel
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortDirection { get; set; }
        public string FilterQuery { get; set; }
        public bool FetchAll { get; set; }
    }
}
