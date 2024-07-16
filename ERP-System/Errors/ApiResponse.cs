using Microsoft.AspNetCore.Http;

namespace ERP_System.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode,string message=null)
        {
            StatusCode=statusCode; 
            Message=message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        
        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A BAd Request ,You Have Made",
                401 => "UnAuthorized",
                404 => "Response Not Found",
                500 => "Enternal server Error",
                _ => null
            };
        }



    }
}
