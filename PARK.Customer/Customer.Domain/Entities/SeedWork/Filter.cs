using System.Collections.Generic;

namespace Domain.Entities
{
    public class Filter
    {
        public IEnumerable<object> Filters { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
    }
}
