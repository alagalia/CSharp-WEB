using System.Text;
using PizzaMVCApp.Utillities;
using PizzaMVCApp.ViewModels;
using SimpleMVC.Interfaces.Generic;

namespace PizzaMVCApp.Views.Menu
{
    public class Suggestions : IRenderable<SuggestionViewModel>
    {
        public string Render()
        {
            StringBuilder suggestedPizzasBuilder = new StringBuilder();

            string top = WebUtils.RetriveContentPathFolder(Constants.MenuSuggestionTop);
            suggestedPizzasBuilder.AppendLine(top);

            suggestedPizzasBuilder.AppendLine(Model.ToString());

            string bottom = WebUtils.RetriveContentPathFolder(Constants.MenuSuggestionBottom);
            suggestedPizzasBuilder.AppendLine(bottom);
            return suggestedPizzasBuilder.ToString();
        }

        public SuggestionViewModel Model { get; set; }
    }
}