using System;
using System.Collections;
using System.Collections.Generic;
using Utility.Interfeces;

namespace Utility
{
    public class CookieCollection : ICookieCollection
    {
        public CookieCollection()
        {
            CookieSet = new Dictionary<string, Cookie>();
        }

        public Cookie this[string key]
        {
            get { return CookieSet[key]; }
            set
            {
                if (this.CookieSet.ContainsKey(key))
                {
                    this.CookieSet[key] = value;
                }
                else
                {
                    this.CookieSet.Add(key, value);
                }
            }
        }

        public IDictionary<string, Cookie> CookieSet { get; private set; }

        public int Count
        {
            get { return this.CookieSet.Count; }
        }
        public void AddCookie(Cookie cookie)
        {
            if (!this.CookieSet.ContainsKey(cookie.Name))
            {
                this.CookieSet.Add(cookie.Name, new Cookie());
            }
            CookieSet[cookie.Name] = cookie;
        }

        public bool ContainsKey(string key)
        {
            return CookieSet.ContainsKey(key);
        }

        public IEnumerator GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void RemoveCookie(string cookieName)
        {
            if (this.CookieSet.ContainsKey(cookieName))
            {
                this.CookieSet.Remove(cookieName);
            }
        }

        

        IEnumerator<Cookie> IEnumerable<Cookie>.GetEnumerator()
        {
            return this.CookieSet.Values.GetEnumerator();
        }
    }
}
