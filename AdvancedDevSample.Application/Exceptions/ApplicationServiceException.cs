using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Application.Exceptions
{
    public class ApplicationServiceException:Exception
    {
        public HttpStatusCode StatusCode { get; }
        public ApplicationServiceException(string v) {
            StatusCode = HttpStatusCode.InternalServerError;
        }
    }
}
