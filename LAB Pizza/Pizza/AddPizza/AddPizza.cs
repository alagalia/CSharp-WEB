using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaMore.Data;
using PizzaMore.Data.Models;
using Utility;

namespace AddPizza
{
    class AddPizza
    {
        private static Session Session;
        private static Header Header = new Header();
        private static IDictionary<string, string> RequestParameters;


        static void Main(string[] args)
        {
            Session = WebUtil.GetSession();
            if (Session != null)
            {
                if (WebUtil.IsGet())
                {
                    ShowPage();
                }
                else if (WebUtil.IsPost())
                {
                    AddPizzaToDB();
                    ShowPage();
                }
            }
            else
            {
                Header.Print();
                WebUtil.PageNotAllowed();
            }
        }

        private static void AddPizzaToDB()
        {
            RequestParameters = WebUtil.RetrievePostParameters();
            string title = RequestParameters["title"];
            string recipe = RequestParameters["recipe"];
            string url = RequestParameters["url"] ?? "no image";
            int userId = Session.User.Id;
            Pizza pizza = new Pizza() {Title = title, ImageUrl = url, OwnerId = userId, DownVotes = 0, Recipe = recipe, UpVotes = 0};
            PmContext cx = new PmContext();
            cx.Pizzas.Add(pizza);
            cx.SaveChanges();
        }

        private static void ShowPage()
        {
            Header.Print();
            WebUtil.PrintFileContent(Constants.Addpizza);
        }
    }
}
