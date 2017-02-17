using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCGI
{
    class Program
    {
        static void Main(string[] args)
        {
            string htmlContent = File.ReadAllText("../htdocs/contact.html");
            string type = "Content-Type: text/html\r\n";

            Console.WriteLine(htmlContent);
            Console.WriteLine(type);

        }
    }
}
