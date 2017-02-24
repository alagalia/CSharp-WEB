using System;
using SimpleHttpServer.Models;

namespace SimpleHttpServer.Utilities
{
    public class SessionCreator
    {
        public  static HttpSession Create()
        {
            //var sessionId = "SessionId" + Guid.NewGuid();
            var sessionId = new Random().Next().ToString();
            HttpSession session = new HttpSession(sessionId);
            return session;
        }
    }
}