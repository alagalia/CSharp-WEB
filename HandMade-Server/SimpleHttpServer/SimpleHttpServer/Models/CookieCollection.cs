using System.Collections;
using System.Collections.Generic;

namespace SimpleHttpServer.Models
{
    public class CookieCollection :IEnumerable<Cookie>
    {
        public CookieCollection()
        {
            this.Cookies = new Dictionary<string, Cookie>();
        }

        public Dictionary<string, Cookie> Cookies { get; private set; }

        public IEnumerator<Cookie> GetEnumerator()
        {
            return this.Cookies.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int Count
        {
            get
            {
                return this.Cookies.Count;
            }
        }

        public bool Contains(string cookieName)
        {
            return this.Cookies.ContainsKey(cookieName);
        }

        public void Add(Cookie cookie)
        {
            this.Cookies.Add(cookie.Name, cookie);
        }

        public Cookie this[string cookieName]
        {
            get { return this.Cookies[cookieName]; }
            set
            {
                if (this.Contains(cookieName))
                {
                    this.Cookies[cookieName] = value;
                }
                else
                {
                    this.Cookies.Add(cookieName, value);
                }
            }
        }

        public override string ToString()
        {
            return string.Join("; ", this.Cookies.Values);
        }
    }
}