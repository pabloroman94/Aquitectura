using System;

namespace Customer.Api.Models.Request
{
    public class UserAddressRequest
    {
        public Guid StreetID { get; set; }
        public Guid CoordinatesID { get; set; }
    }
}
