namespace CustomerApp.Api.CustomEntities
{
    public class PagedResponseHeader
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public int? NextPageNumber => HasNextPage ? CurrentPage + 1 : (int?)null;

        public int? PreviousPageNumber => HasNextPage ? CurrentPage - 1 : (int?)null;

        public string NextPageUrl { get; set; }
        public string PreviousPageUrl { get; set; }


        public PagedResponseHeader(int currentPage, int totalPages, int pageSize, int totalCount, string nextPageUrl, string previousPageUrl)
        {
            CurrentPage = currentPage;
            TotalPages = totalPages;
            PageSize = pageSize;
            TotalCount = totalCount;
            NextPageUrl = HasNextPage ? nextPageUrl : "";
            PreviousPageUrl = HasPreviousPage ? previousPageUrl : "";
        }

        public PagedResponseHeader()
        {
        }
    }
}