using System;
using System.Text;using Utility.Interfeces;

namespace Utility
{
    public class Header
    {
        public string Type { get; set; }

        public string Location { get; private set; }

        public ICookieCollection Cookies { get; private set; }

        public Header()
        {
            this.Type = "Content-type: text/html";
            Cookies = new CookieCollection();
        }
        

        public void AddLocation(string location)
        {
            this.Location = $"Location: {location}";
        }

        public void AddCookie(Cookie cookie)
        {
            Cookies.AddCookie(cookie);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.Type);
            if (Cookies.Count != 0)
            {
                foreach (Cookie cookie in this.Cookies)
                {
                    sb.AppendLine($"Set-Cookie: {cookie.ToString()}");
                }

            }

            if (!string.IsNullOrEmpty(this.Location))
            {
                sb.AppendLine(this.Location);
            }

            sb.AppendLine();
            sb.AppendLine();

            return sb.ToString();
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
