using System;
using SimpleHttpServer.Models;

namespace SimpleHttpServer.Utilities
{
    public class SessionCreator
    {
        public  static HttpSession Create()
        {
            var sessionId = "Sid" + Guid.NewGuid();
            //TODO check if this Guid.NewGuid() work

            HttpSession session = new HttpSession(sessionId);
            return session;
        }
    }
}