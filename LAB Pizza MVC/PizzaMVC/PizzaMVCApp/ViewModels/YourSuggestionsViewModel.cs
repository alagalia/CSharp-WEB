using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaMVCApp.ViewModels
{
    public class YourSuggestionsViewModel
    {
        public YourSuggestionsViewModel()
        {
            YourSuggestedPizzas = new List<PizzaViewModel>();
        }

        public string Email { get; set; }
        public ICollection<PizzaViewModel> YourSuggestedPizzas { get; set; }

        public override string ToString()
        {
            StringBuilder yourSuggestionPreView = new StringBuilder();

            yourSuggestionPreView.AppendLine("<ul>");
            foreach (var suggestion in YourSuggestedPizzas)
            {
                yourSuggestionPreView.AppendLine("<form method=\"POST\">");
                yourSuggestionPreView.AppendLine($"<li><a href=\"DetailsPizza.exe?pizzaid={suggestion.Id}\">{suggestion.Title}</a> <input type=\"hidden\" name=\"pizzaId\" value=\"{suggestion.Id}\"/> <input type=\"submit\" class=\"btn btn-sm btn-danger\" value=\"X\"/></li>");
                yourSuggestionPreView.AppendLine("</form>");
            }
            yourSuggestionPreView.AppendLine("</ul>");

            return YourSuggestedPizzas.ToString();
        }

    }
}