using System;
using System.IO;
using System.Reflection;

namespace StreamForHTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string stream = File.ReadAllText(@"D:/SOFTUNI-C#/C#WEB/01-02.Web Fundamentals Introduction + HTTP Protocol/01.Intro-HTTP/HTMLs/AddCake.html");
            Console.WriteLine("Content-type: text/html\r\n");
            Console.WriteLine(stream);
            string fileName = typeof(Program).Namespace + ".exe";// Path.GetFileName(Assembly.GetExecutingAssembly().Location);
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;

            string sourcePath = path.Replace("\\" + fileName, ""); ;
            string targetPath = @"D:\xampp\cgi-bin";

            string sourceFile = Path.Combine(sourcePath, fileName);
            string destFile = Path.Combine(targetPath, fileName);

            File.Copy(sourceFile, destFile, true);

            //string[] files = Directory.GetFiles(sourcePath);
            //foreach (string s in files)
            //{
            //    fileName = Path.GetFileName(s);
            //    destFile = Path.Combine(targetPath, fileName);
            //    File.Copy(s, destFile, true);
            //}

        }
    }
}
