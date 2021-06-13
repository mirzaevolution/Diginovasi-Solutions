namespace Diginovasi.Api.Models
{
    public class BaseResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; } = true;
    }
    public class Response<T>:BaseResponse
    {
        public T Data { get; set; }
        
    }
}
