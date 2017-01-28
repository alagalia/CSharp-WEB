using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string stream = File.ReadAllText(@"D:\SOFTUNI-C#\C#WEB\01.Web Fundamentals Introduction + HTTP Protocol\Calculator\Calculator\Calc.html");
            Console.WriteLine("Content-type: text/html\r\n");
            Console.WriteLine(stream);

            string content = Environment.GetEnvironmentVariable("QUERY_STRING");
            if(string.IsNullOrEmpty(content)) return;
            string[] vars = content.Split('&');
            if (string.IsNullOrEmpty(vars[0])) return;
            if (string.IsNullOrEmpty(vars[1])) return;
            if (string.IsNullOrEmpty(vars[2])) return;

            int a = int.Parse(vars[0].Split('=')[1]);
            int b = int.Parse(vars[2].Split('=')[1]);
            Console.WriteLine("Result: " + vars[1].Split('=')[1]);
            switch (vars[1].Split('=')[1])
            {
                case "-": //-
                    Console.WriteLine(a - b); break;
                case "%2B": //+
                    Console.WriteLine(a + b); break;
                case "*": //*
                    Console.WriteLine(a * b); break;
                case "%3A":
                    Console.WriteLine(a / b); break;
            }
            Console.WriteLine();
        }
    }
}
