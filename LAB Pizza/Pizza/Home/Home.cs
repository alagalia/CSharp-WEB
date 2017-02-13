using System;
using System.Collections.Generic;
using PizzaMore.Data;
using PizzaMore.Data.Models;
using Utility;

namespace Home
{
    internal class Home
    {
        private static IDictionary<string, string> RequestParameters;

        private static Session Session;

        private static Header Header = new Header();

        private static string Language;


        static void Main()
        {

            AddDefaultLanguageCookie();

            if (WebUtil.IsGet())
            {
                RequestParameters = WebUtil.RetrieveGetParameters();
                TryLogOut();
                Language = WebUtil.GetCookies()["lang"].Value;

            }
            else if (WebUtil.IsPost())
            {
                RequestParameters = WebUtil.RetrievePostParameters();
                Header.AddCookie(new Cookie("lang", RequestParameters["language"]));
                Language = RequestParameters["language"];
            }

            ShowPage();
        }

        private static void TryLogOut()
        {
            if (RequestParameters.ContainsKey("logout"))
            {
                if (RequestParameters["logout"] == "true")
                {
                    Session = WebUtil.GetSession();
                    using (var context = new PmContext())
                    {
                        var s = context.Sessions.Find(Session.Id);
                        context.Sessions.Remove(s);
                        context.SaveChanges();
                    }
                }
            }
        }

        public static void AddDefaultLanguageCookie()
        {
            var cookies = WebUtil.GetCookies();
            if (!cookies.ContainsKey("lang"))
            {
                Header.AddCookie(new Cookie("lang", "EN"));
                Language = "EN";
            }
            ShowPage();
        }

        private static void ShowPage()
        {
            
            if (Language == "EN")
            {
                Header.Print();
                WebUtil.PrintFileContent("../../htdocs/pm/home.html");
            }
            else if (Language == "DE")
            {
                Header.Print();
                WebUtil.PrintFileContent("../../htdocs/pm/home-de.html");
            }
        }
    }
}