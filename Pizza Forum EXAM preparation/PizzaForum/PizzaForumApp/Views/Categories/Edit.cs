using System;
using System.Text;
using PizzaForumApp.Models;
using PizzaForumApp.Utillities;
using PizzaForumApp.ViewModels;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace PizzaForumApp.Views.Categories
{
    public class Edit: IRenderable<CategoryEditViewModel>
    {
        public CategoryEditViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(WebUtils.RetriveContentPathFolder(Constants.Header));

            string navLogged = WebUtils.RetriveContentPathFolder(Constants.NavLogged);
            htmlContent.AppendLine(string.Format(navLogged, ViewBag.Bag["username"]));

            string editTemplate = WebUtils.RetriveContentPathFolder(Constants.AdminCategoryEdit);
            htmlContent.AppendLine(string.Format(editTemplate, Model.Category.Name, Model.Category.Id));

            htmlContent.AppendLine(WebUtils.RetriveContentPathFolder(Constants.Footer));
            return htmlContent.ToString();
        }

    }
}