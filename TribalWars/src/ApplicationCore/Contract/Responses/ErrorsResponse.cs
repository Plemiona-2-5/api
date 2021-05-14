using System.Collections.Generic;

namespace ApplicationCore.Contract.Responses
{
    public class ErrorsResponse
    {
        public IEnumerable<string> Errors { get; set; }

        public ErrorsResponse(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        public ErrorsResponse(string error)
        {
            Errors = new[] {error};
        }
    }
}