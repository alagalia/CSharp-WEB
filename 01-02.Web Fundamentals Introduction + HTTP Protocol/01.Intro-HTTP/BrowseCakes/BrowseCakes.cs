using System;
using System.IO;
using System.Linq;

namespace BrowseCakes
{
    class BrowseCakes
    {
        static void Main(string[] args)
        {

            string stream = File.ReadAllText(@"D:/SOFTUNI-C#/C#WEB/01-02.Web Fundamentals Introduction + HTTP Protocol/01.Intro-HTTP/HTMLs/BrowseCakes.html");
            Console.WriteLine("Content-type: text/html\r\n");
            Console.WriteLine(stream);

            string getContext = Environment.GetEnvironmentVariable("QUERY_STRING");//get variables from forms
            Console.WriteLine(getContext);
            if (string.IsNullOrEmpty(getContext)) return;
            string searchedCake = getContext.Split('=')[1];

            string[] csv = File.ReadAllLines(@"../htdocs/files/cakes.csv");
            //Console.WriteLine(string.Join(",", csv));
            var matchedCakes = csv.Where(d => d.ToLower().Contains(searchedCake.ToLower()));
            foreach (string row in matchedCakes)
            {
                string[] cake = row.Split(';');
                Console.WriteLine($@"<p>{cake[0]} ${cake[1]}</p>");
            }
        }
    }
}
