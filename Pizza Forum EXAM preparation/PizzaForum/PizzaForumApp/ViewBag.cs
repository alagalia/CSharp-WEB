using System.Collections;
using System.Collections.Generic;

namespace PizzaForumApp
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