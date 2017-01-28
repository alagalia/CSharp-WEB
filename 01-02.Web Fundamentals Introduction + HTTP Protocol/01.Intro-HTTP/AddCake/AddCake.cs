using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddCake
{
    class AddCake
    {

        static void Main()
        {
            string pathForHTML =
                @"D:\SOFTUNI-C#\C#WEB\01-02.Web Fundamentals Introduction + HTTP Protocol\01.Intro-HTTP\HTMLs\AddCake.html";
            string stream = File.ReadAllText(pathForHTML);
            Console.WriteLine("Content-type: text/html\r\n");
            Console.WriteLine(stream);
           
            string addedInfoForCake = Environment.GetEnvironmentVariable("QUERY_STRING");
            if (!string.IsNullOrEmpty(addedInfoForCake))
            {
                AddCakeToDb(addedInfoForCake);
            }
            

        }

        private static void AddCakeToDb(string addedInfoForCake)
        {
            string name = string.Empty;
            double price = 0;
            string[] requestInfo = addedInfoForCake.Split('&');
            foreach (string req in requestInfo)
            {
                if (req.ToLower().Contains("name"))
                {
                    name = req.Split('=')[1].Replace("+", " ");
                }
                else
                {
                    price=double.Parse(req.Split('=')[1]);
                }

            }
            string row = Environment.NewLine + $"{name};{price}";
            File.AppendAllText(@"../htdocs/files/cakes.csv", row);

        }
    }
}
