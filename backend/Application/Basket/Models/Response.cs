namespace Basket.Models
{
    public class Response<T> where T : class
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; } 
        public T Data { get; set; }
    }
}
