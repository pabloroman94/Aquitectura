
namespace PARK.CustomerApi.Models
{
    public class ErrorModel
    {
        public ErrorModel(int code, string message)
        {
            Message = message;
            Code = code;
        }
        /// <summary>
        /// Codigo del error
        /// </summary>
        /// <example>404</example>
        public int Code { get; set; }
        /// <summary>
        /// Mensaje del error o excepcion
        /// </summary>
        /// <example> Server not found</example>
        public string Message { get; set; }
    }
}