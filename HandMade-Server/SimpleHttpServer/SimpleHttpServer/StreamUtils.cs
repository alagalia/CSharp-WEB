using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SimpleHttpServer.Models;

namespace SimpleHttpServer
{
    public class StreamUtils
    {
        
        public static string ReadLine(Stream stream)
        {
            StringBuilder sb = new StringBuilder();
            int nextChar;
            while (true)
            {
                nextChar = stream.ReadByte();
                if(nextChar == '\n') { break;}
                if(nextChar == '\r') { continue;}
                if (nextChar == -1)
                {
                    Thread.Sleep(1);
                    continue;
                }
                sb.Append((char) nextChar);
            }
            return sb.ToString();
        }

        public static void WriteResponse(Stream stream, HttpResponse response)
        {
            byte[] responseHeader = Encoding.UTF8.GetBytes(response.ToString());
            stream.Write(responseHeader,0, responseHeader.Length);
            stream.Write(response.Content, 0, response.Content.Length);
        }
    }
}
