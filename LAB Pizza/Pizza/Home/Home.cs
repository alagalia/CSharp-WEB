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
                //TryLogOut();
                Language = WebUtil.GetCookies()["lang"].Value;

            }
            else if (WebUtil.IsPost())
            {
                RequestParameters = WebUtil.RetrievePostParameters();
                Cookie newCookie = new Cookie("lang", RequestParameters["language"]);
                Header.AddCookie(newCookie);
                Language = RequestParameters["language"];
            }

            ShowPage();
        }

        public static void AddDefaultLanguageCookie()
        {
            if (!WebUtil.GetCookies().ContainsKey("lang"))
            {
                Header.AddCookie(new Cookie("lang", "EN"));
                Language = "EN";
            }
        }

        private static void ShowPage()
        {
            Header.Print();
            
            if (Language == "EN")
            {
                WebUtil.PrintFileContent(Constants.HomePageEN);
            }
            else 
            {
                WebUtil.PrintFileContent("../../htdocs/pm/home-de.html");
            }
        }
    }
}