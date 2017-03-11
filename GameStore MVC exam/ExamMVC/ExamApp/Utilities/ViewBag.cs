using System.Collections.Generic;

namespace ExamApp.Utilities
{
    public class ViewBag
    {
        public static IDictionary<string, dynamic> Bag = new Dictionary<string, dynamic>();

        public static dynamic GetUserName()
        {
            if (Bag.ContainsKey("username"))
            {
                return Bag["username"];
            }

            return null;
        }
    }
}