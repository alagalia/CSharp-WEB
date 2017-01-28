using System;
using System.IO;

namespace HomeCake
{
    class HomeCake 
    {
        static void Main()
        {
            string stream = File.ReadAllText(@"D:/SOFTUNI-C#/C#WEB/01-02.Web Fundamentals Introduction + HTTP Protocol/01.Intro-HTTP/HTMLs/Index.html");
            Console.WriteLine("Content-type: text/html\r\n");
            Console.WriteLine(stream);
        }
    }
}
