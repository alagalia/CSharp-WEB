using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PizzaMore.Data;
using PizzaMore.Data.Models;
using Utility;

namespace SignUp
{
    class SignUp
    {
        public static IDictionary<string, string> RequestParameters;
        public static Header Header = new Header();

        static void Main(string[] args)
        {
            if (WebUtil.IsPost())
            {
                RegisterUser();
            } 
            ShowPage();
        }

        private static void ShowPage()
        {
            Header.Print();
            WebUtil.PrintFileContent(Constants.SignUp);

        }

        private static void RegisterUser()
        {
            var user = WebUtil.RetrievePostParameters();
            string email = user["email"];
            string pass = PasswordHasher.Hash(user["password"]);
            using (var cx = new PmContext())
            {
                cx.Users.Add(new User { Email = email, Password = pass });
                cx.SaveChanges();
            }
            
        }
    }
}
