using System;
using System.Collections.Generic;
using System.Text;
using PizzaForumApp.Security;
using PizzaForumApp.Utillities;
using PizzaForumApp.ViewModels;
using SimpleHttpServer.Models;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace PizzaForumApp.Views.Categories
{
    public class All :IRenderable<CategoriesAllViewModel>
    {
        public CategoriesAllViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(WebUtils.RetriveContentPathFolder(Constants.Header));
            string navLogged = WebUtils.RetriveContentPathFolder(Constants.NavLogged);
            navLogged = String.Format(navLogged,Model.User.Username);
            htmlContent.AppendLine(navLogged);

            StringBuilder categories = new StringBuilder();
            foreach (CategorySectionViewModel model in Model.CategoriesModels)
            {
                categories.AppendLine(model.ToString());
            }
            string container = WebUtils.RetriveContentPathFolder(Constants.AdminCategories);

            htmlContent.AppendLine(string.Format(container, categories));
            htmlContent.AppendLine(WebUtils.RetriveContentPathFolder(Constants.Footer));
            return htmlContent.ToString();
        }

    }
}