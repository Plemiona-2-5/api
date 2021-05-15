using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Response
{
    public class Response
    {
        public string ResponseMessage { get; set; }

        public Response(string responseMessage)
        {
            ResponseMessage = responseMessage;
        }
    }
}
