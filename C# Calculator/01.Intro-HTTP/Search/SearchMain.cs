using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    class SearchMain
    {
        static void Main(string[] args)
        {
            string htmlContent = File.ReadAllText("../../htdocs/exam1/search.html");
            //string htmlContent = File.ReadAllText("../htdocs/Brasil/Brasil.html");
            string type = "Content-Type: text/html\r\n";

            Console.WriteLine(type);
            Console.WriteLine(htmlContent);

            string getContext = Environment.GetEnvironmentVariable("QUERY_STRING");//get variables from forms
            Console.WriteLine("context: " + getContext);
            string method = Environment.GetEnvironmentVariable("REQUEST_METHOD"); //get method used in forms
            Console.WriteLine("method: " + method);
            Console.WriteLine("cookies: " + Environment.GetEnvironmentVariable("HTTP_COOKIE"));
            if (string.IsNullOrEmpty(getContext)) return;
            string searched = getContext.Split('=')[1];
            string[] someNames = { "Ivan", "Pesho", "Irina", "Zoq", "Krasimir", "Rumqna", "Sonq" };
            if (method == "GET")
            {
                foreach (string name in someNames)
                {
                    if (name.ToLower().Contains(searched.ToLower()))
                    {
                        Console.WriteLine(name);
                    }
                }
                Console.WriteLine(searched);
            }
            else if (method == "POST")
            {
                Console.WriteLine("Method POST is unvalivable.");
            }
            else
            {
                Console.WriteLine(method);
            }
        }
    }
}
