using Domain.Entities;
using System;

namespace CustomerApp.Api.Services
{
    public interface IUriService
    {
        Uri GetPageUri(Filter filters, string route);
    }
}
