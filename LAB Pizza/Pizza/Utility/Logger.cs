using System;
using System.IO;

namespace Utility
{
    public static class Logger
    {
        public static void Log(string message )
        {
            string path = @"log.txt";
            File.AppendAllText(path, message + Environment.NewLine);
        }
    }
}