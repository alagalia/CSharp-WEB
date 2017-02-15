using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;

namespace SimpleHttpServer
{
    public class HttpProcessor
    {
        public IList<Route> Routes { get; set; }
        public HttpRequest Request { get; set; }
        public HttpResponse Response { get; set; }

        public HttpProcessor(IEnumerable<Route> routes )
        {
            this.Routes = new List<Route>(routes);
        }

        public void HandleClient(TcpClient tcpClient)
        {
            using (var stream = tcpClient.GetStream())
            {
                Request = GetRequest(stream);
                Response = RouteSequest();
                StreamUtils.WriteResponse(stream, Response);
            }
        }

        private HttpResponse RouteSequest()
        {
            string requestUrl = Request.Url;
            var matchingRoutes = this.Routes
                .Where(r => new Regex(r.UrlRegex).IsMatch(requestUrl));

            if (!Routes.Any())
            {
                return HttpResponseBuilder.NotFound();
            }
            
            var route = Routes.SingleOrDefault(x => x.Method == Request.Method);
            if (route == null)
            {
                return new HttpResponse()
                {
                    StatusCode = ResponseStatusCode.Method_Not_Allowed
                };
            }

            //trigger root handler
            try
            {
                HttpResponse response = route.Callable(Request);
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return HttpResponseBuilder.InternalServerError();
            }
        }

        private HttpRequest GetRequest(NetworkStream stream)
        {
            //read request line
            string firstLine = StreamUtils.ReadLine(stream);
            string[] tokens = firstLine.Split(' ');
            if (tokens.Length != 3 )
            {
                throw new ArgumentException("Invalid elements or request!");
            }

            RequestMethod method = RequestMethod.GET;
            if (tokens[0].ToLower() == "post")
            {
                method = RequestMethod.POST;
            }

            string url = tokens[1];
            string portocolVer = tokens[2];

            //read headers
            Header header = new Header(HeaderType.HttpRequest);
            string line;
            while ((line = StreamUtils.ReadLine(stream)) != null)
            {
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }
                int separator = line.IndexOf(':');
                if (separator == -1)
                {
                    throw new Exception("Invalid Http line: " + line);
                }

                string name = line.Substring(0, separator);
                int currentPos = separator + 1;
                while (currentPos< line.Length && line[currentPos] == ' ')
                {
                    currentPos++;
                }

                string value = line.Substring(currentPos, line.Length - currentPos);
                
                if (name.ToLower() == "cookie")
                {
                    string[] allCookies = value.Split(';');
                    foreach (string cookieForSave in allCookies)
                    {
                        string[] cookieKV = cookieForSave.Split('=').Select(c => c.Trim()).ToArray();
                        Cookie cookie = new Cookie(cookieKV[0], cookieKV[1]);
                        header.Cookies.Add(cookie);
                    }
                }
                else if (name.ToLower() == "content-length ")
                {
                    header.ContentLenght = value;
                }
                else
                {
                    header.OtherParameters.Add(name, value);
                }
            }

            string content = null;
            if (header.ContentLenght != null)
            {
                int totalBytes = Convert.ToInt32(header.ContentLenght);
                int bytesLeft = totalBytes;
                byte[] bytes = new byte[totalBytes];

                while (bytesLeft>0)
                {
                    byte[] buffer = new byte[bytesLeft > 1024 ? 1024 : bytesLeft];
                    int n = stream.Read(buffer, 0, buffer.Length);
                    buffer.CopyTo(bytes, totalBytes - bytesLeft);
                    bytesLeft -= n;
                }

                content = Encoding.ASCII.GetString(bytes);
            }

            var request = new HttpRequest(method, url)
            {
                Content = content,
                Header = header
            };
            return request;
        }
    }
}
