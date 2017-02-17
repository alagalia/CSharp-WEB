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
            //Console.WriteLine(Console.ReadLine());

            //string addedInfoForCake = Environment.GetEnvironmentVariable("QUERY_STRING");
            string addedInfoForCake = Console.ReadLine();
            if (!string.IsNullOrEmpty(addedInfoForCake))
            {
                AddCakeToDb(addedInfoForCake);
            }


        }

        private static void AddCakeToDb(string addedInfoForCake)
        {
            string name = string.Empty;
            double price = 0;
            string[] variables = addedInfoForCake.Split('&');
            foreach (string req in variables)
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
            string row = $"{name};{price}" + Environment.NewLine;
            File.AppendAllText(@"../htdocs/files/cakes.csv", row);

        }
    }
}
