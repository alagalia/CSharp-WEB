using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentDesposition
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream stream = File.Open("../htdocs/files/pesho.txt", FileMode.Open);
            long fileSize = stream.Length;
            Console.WriteLine($"Content-Type: text/plain\r\nContent-Lenght: {fileSize}\r\nContent-Disposition: attachment; filename=exam.txt\r\n");
            stream.Close();
            string[] readLines = File.ReadAllLines("../htdocs/files/pesho.txt");

            foreach (string readLine in readLines)
            {
                Console.WriteLine(readLine);
            }
        }
    }
}
