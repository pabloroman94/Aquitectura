
namespace PARK.CustomerApi.Models
{
    public class ErrorResponseModel
    {
        public ErrorResponseModel(int code = 0, string message = "")
        {
            Error = new ErrorModel(code, message);
        }

        public ErrorModel Error { get; set; }
    }
}