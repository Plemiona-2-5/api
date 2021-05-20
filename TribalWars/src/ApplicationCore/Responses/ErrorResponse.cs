using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Responses
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
            Errors = new[] { error };
        }
    }
}
