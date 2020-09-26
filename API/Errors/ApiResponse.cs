using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessage(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }


        private string GetDefaultMessage(int statusCode)
        {
            return  statusCode switch
            {
                400 => "Bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource found, it was not",
                500 => "Error leads to dark side. Errors lead to anger, anger leads to hate, hate leads to career change",
                _ => null
            };
        }
    }
}