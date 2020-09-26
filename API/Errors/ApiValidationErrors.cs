using System.Collections.Generic;

namespace API.Errors
{
    public class ApiValidationErrors : ApiResponse
    {
        public ApiValidationErrors() : base(400)
        {
        }

        public IEnumerable<string> Errors { get; set; }
    }
}