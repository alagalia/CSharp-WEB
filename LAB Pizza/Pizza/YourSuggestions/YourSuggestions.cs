using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaMore.Data;
using PizzaMore.Data.Models;
using Utility;

namespace YourSuggestions
{
    class YourSuggestions
    {
        private static Session Session;
        private static IDictionary<string, string> RequestParameters;
        private static Header Header = new Header();

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
                    DeletePizza();
                    ShowPage();
                }
            }
            else
            {
                Header.Print();
                WebUtil.PageNotAllowed();
            }
        }

        private static void DeletePizza()
        {
            RequestParameters = Utility.WebUtil.RetrievePostParameters();
            int pizzaToRemoveId = int.Parse(RequestParameters["pizzaId"]);
            using (PmContext cx = new PmContext())
            {
                Pizza pizzaToRemove = cx.Pizzas.Find(pizzaToRemoveId);
                //cx.Pizzas.Remove(cx.Pizzas.First(p => p.Id == pizzaToRemoveId));
                cx.Pizzas.Remove(pizzaToRemove);
                cx.SaveChanges();
            }
            
        }

        private static void ShowPage()
        {
            Header.Print();
            WebUtil.PrintFileContent(Constants.YoursuggestionsTop);
            PrintListOfSuggestedItems();
            WebUtil.PrintFileContent(Constants.YoursuggestionsBottom);
        }

        private static void PrintListOfSuggestedItems()
        {
            PmContext cx = new PmContext();
            var suggestions = cx.Pizzas.Where(p => p.OwnerId == Session.User.Id);

            Console.WriteLine("<ul>");
            foreach (var suggestion in suggestions)
            {
                Console.WriteLine("<form method=\"POST\">");
                Console.WriteLine($"<li><a href=\"DetailsPizza.exe?pizzaid={suggestion.Id}\">{suggestion.Title}</a> <input type=\"hidden\" name=\"pizzaId\" value=\"{suggestion.Id}\"/> <input type=\"submit\" class=\"btn btn-sm btn-danger\" value=\"X\"/></li>");
                Console.WriteLine("</form>");
            }
            Console.WriteLine("</ul>");

        }
    }
}
