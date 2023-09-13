using CustomerApp.Api.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerApp.Api.CustomEntities
{
    public static class PagedList
    {
        public static PagedResponse<T> Create<T>(IEnumerable<T> source, Filter filter, string route, IUriService uriService)
        {
            var count = source.Count();
            var items = source.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize).ToList();

            return new PagedResponse<T>(items, filter.PageNumber, (int)Math.Ceiling(count / (double)filter.PageSize),
                                 filter.PageSize, count, uriService.GetPageUri(filter, route).ToString(), uriService.GetPageUri(filter, route).ToString());
        }
    }
}
