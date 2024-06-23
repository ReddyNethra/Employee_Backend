using System.Net;

namespace Employee_API.Model
{
    public class ApiResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessages { get; set; }
        public object result { get; set; }
    }
}
