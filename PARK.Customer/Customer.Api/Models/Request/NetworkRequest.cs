using Org.BouncyCastle.Utilities.IO.Pem;
using System;

namespace Customer.Api.Models.Request
{
    public class NetworkRequest
    {
        public string Description { get; set; }
        public string URL { get; set; }
        public Guid NetworkTypeID { get; set; }
    }
}
