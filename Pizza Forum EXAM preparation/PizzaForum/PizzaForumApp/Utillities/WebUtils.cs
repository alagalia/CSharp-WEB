using System.IO;

namespace PizzaForumApp.Utillities
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