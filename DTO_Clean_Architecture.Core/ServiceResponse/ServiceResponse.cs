namespace DTO_Clean_Architecture.Core.ServiceResponse
{
    public class ServiceResponse<T> where T : class
    {
        public bool Status { get;set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<T> Result { get; set; }

        public ServiceResponse(bool status, string message, T data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
        public ServiceResponse(bool status, string message, List<T> result)
        {
            Status = status;
            Message = message;
            Result = result;
        }
        public ServiceResponse(bool status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
