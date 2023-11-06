namespace AP.Models
{
    public class ApiResponseViewModel<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<T> DataList { get; set; }
    }
}
