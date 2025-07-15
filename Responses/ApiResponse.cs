

namespace ClinicAPI.Responses
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public bool Success { get; set; }

        public ApiResponse() { }

        public ApiResponse(int statusCode, string message, T? data = default)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
            Success = statusCode >= 200 && statusCode < 300;

        }
    }
}
