using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleHttpServer.Enums;

namespace SimpleHttpServer.Models
{
    public static class HttpResponseBuilder
    {
        public static HttpResponse InternalServerError()
        {
            HttpResponse response = new HttpResponse()
            {
                StatusCode = ResponseStatusCode.Internal_Server_Error
            };
            string content = "<h1>500 – Internal Sever Error</h1>";
            response.ContentAsUTF8 = content;
            return response;
        }

        public static HttpResponse NotFound()
        {
            HttpResponse response = new HttpResponse()
            {
                StatusCode = ResponseStatusCode.Page_Not_Found
            };
            string content = "<h1>404 – Resource Not Found</h1>";
            response.ContentAsUTF8 = content;
            return response;
        }
    }
}
