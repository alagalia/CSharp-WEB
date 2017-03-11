using System.IO;

namespace ExamApp.Utilities
{
    public class WebUtils
    {
        public static string RetriveContentPathFolder(string path)
        {
            string content = File.ReadAllText(path);
            return content;
        }
    }
}