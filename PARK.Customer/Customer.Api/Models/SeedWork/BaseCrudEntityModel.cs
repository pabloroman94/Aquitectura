using PARK.CustomerApi.Models.SeedWork;

namespace CustomerApp.Api.Models.SeedWork
{
    public class BaseCrudEntityModel<TPrimaryKey> : BaseStampEntityModel<TPrimaryKey>
    {
        public string Code { get; set; }
    }
}
