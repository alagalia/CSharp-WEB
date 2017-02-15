using System.Collections.Generic;
using System.Text;
using SimpleHttpServer.Enums;

namespace SimpleHttpServer.Models
{
    public class Header
    {
        public Header(HeaderType type)
        {
            this.Type = type;
            this.ContentType = "Content-type: text/html";
            this.Cookies = new CookieCollection();
            this.OtherParameters = new Dictionary<string, string>();
        }
        public HeaderType Type { get; set; }
        public string ContentType { get; set; }
        public string ContentLenght { get; set; }
        public Dictionary<string,string> OtherParameters { get; set; }
        public CookieCollection Cookies { get; private set; }

        public override string ToString()
        {
            StringBuilder header = new StringBuilder();
            header.AppendLine(this.ContentType);
            if (this.Cookies.Count > 0)
            {
                if (Type == HeaderType.HttpRequest)
                {
                    header.AppendLine("Cookie: " + this.Cookies);
                }
                else if (Type == HeaderType.HttpResponse)
                {
                    foreach (var cookie in this.Cookies)
                    {
                        header.AppendLine("Set-Cookie: " + cookie);
                    }
                }
            }
            if (this.ContentLenght != null)
            {
                header.AppendLine("Content-Lenght: " + this.ContentLenght);
            }
            foreach (var other in this.OtherParameters)
            {
                header.AppendLine($"{other.Key}: {other.Value}");
            }
            header.AppendLine();
            header.AppendLine();
            return header.ToString();
        }
    }
}