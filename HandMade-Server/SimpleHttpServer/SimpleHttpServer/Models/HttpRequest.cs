using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using SimpleHttpServer.Enums;

namespace SimpleHttpServer.Models
{
    public class HttpRequest
    {
        public HttpRequest(RequestMethod method, string url)
        {
            Method = method;
            Url = url;
            Header = new Header(HeaderType.HttpRequest);
        }

        public RequestMethod Method { get; private set; }
        public string Url { get; set; }
        public Header Header { get; set; }
        public string Content { get; set; }

        public override string ToString()
        {
            StringBuilder request = new StringBuilder();

            request.AppendLine($"{this.Method.ToString()} {this.Url} HTTP/1.0");
            request.AppendLine(this.Header.ToString());
            if (!string.IsNullOrEmpty(Content) && Method == RequestMethod.POST)
            {
                request.AppendLine();
                request.AppendLine(Content);
            }
            return request.ToString();
        }
    }
}
