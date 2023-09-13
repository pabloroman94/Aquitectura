using System.Collections.Generic;

namespace CustomerApp.Api.CustomEntities
{
    public class PagedResponse<T> : List<T>
    {
        public PagedResponseHeader pagedResponseHeader { get; set; }
        public List<T> items { get; set; }

        public PagedResponse(List<T> items, int currentPage, int totalPages, int pageSize, int totalCount, string nextPageUrl, string previousPageUrl)
        {
            PagedResponseHeader _pagedResponseHeader = new PagedResponseHeader
            {
                CurrentPage = currentPage,
                TotalPages = totalPages,
                PageSize = pageSize,
                TotalCount = totalCount,
                NextPageUrl = (currentPage < totalPages) ? nextPageUrl : "",
                PreviousPageUrl = (currentPage > 1) ? previousPageUrl : ""
            };

            this.pagedResponseHeader = _pagedResponseHeader;
            AddRange(items);
        }
    }
}