using System;
using System.Collections.Generic;
using System.Text;
using PizzaMVCApp.Utillities;
using PizzaMVCApp.ViewModels;
using SimpleMVC.Interfaces.Generic;

namespace PizzaMVCApp.Views.Menu
{
    public class Index : IRenderable<SuggestionViewModel>
    {
        public SuggestionViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder pizzaSuggestionsBuilder = new StringBuilder();

            string navBar = "<nav class=\"navbar navbar-default\">" +
                "<div class=\"container-fluid\">" +
                "<div class=\"navbar-header\">" +
                "<a class=\"navbar-brand\" href=\"home/index\">PizzaMore</a>" +
                "</div>" +
                "<div class=\"collapse navbar-collapse\" id=\"bs-example-navbar-collapse-1\">" +
                "<ul class=\"nav navbar-nav\">" +
                "<li ><a href=\"/menu/add\">Suggest Pizza</a></li>" +
                "<li><a href=\"/menu/suggestions\">Your Suggestions</a></li>" +
                "</ul>" +
                "<ul class=\"nav navbar-nav navbar-right\">" +
                "<p class=\"navbar-text navbar-right\"></p>" +
                "<p class=\"navbar-text navbar-right\"><a href=\"/users/logout\" class=\"navbar-link\">Sign Out</a></p>" +
                $"<p class=\"navbar-text navbar-right\">Signed in as {Model.Email}</p>" +
                "</ul> </div></div></nav>";
            pizzaSuggestionsBuilder.AppendLine(navBar);

            string top = WebUtils.RetriveContentPathFolder(Constants.MenuTop);
            pizzaSuggestionsBuilder.AppendLine(top);

            pizzaSuggestionsBuilder.AppendLine(Model.ToString());

            string bottom = WebUtils.RetriveContentPathFolder(Constants.MenuBottom);
            pizzaSuggestionsBuilder.AppendLine(bottom);

            return pizzaSuggestionsBuilder.ToString();
        }

    }
}