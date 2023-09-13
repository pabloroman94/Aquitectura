
namespace PARK.CustomerApi.Models
{
    public class ApiResponseModel<T> : ErrorResponseModel
    {
        public ApiResponseModel(T data, int code = 0, string message = "")
            : base(code, message)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}