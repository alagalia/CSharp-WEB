using System;
using System.Collections.Generic;
using System.Text;
using PizzaMVCApp.Models;

namespace PizzaMVCApp.ViewModels
{
    public class SuggestionViewModel
    {
        public SuggestionViewModel()
        {
            PizzaSuggestions = new List<PizzaViewModel>();
        }
        public string Email { get; set; }

        public ICollection<PizzaViewModel> PizzaSuggestions { get; set; }

        public override string ToString()
        {
            StringBuilder pizzaSuggestionPreView = new StringBuilder();

            pizzaSuggestionPreView.AppendLine("<div class=\"card-deck\">");
            foreach (var pizza in this.PizzaSuggestions)
            {
                pizzaSuggestionPreView.AppendLine("<div class=\"card\">");
                pizzaSuggestionPreView.AppendLine($"<img class=\"card-img-top\" src=\"{pizza.ImageUrl}\" width=\"200px\"alt=\"Card image cap\">");
                pizzaSuggestionPreView.AppendLine("<div class=\"card-block\">");
                pizzaSuggestionPreView.AppendLine($"<h4 class=\"card-title\">{pizza.Title}</h4>");
                pizzaSuggestionPreView.AppendLine($"<p class=\"card-text\"><a href=\"DetailsPizza.exe?pizzaid={pizza.Id}\">Recipe</a></p>");
                pizzaSuggestionPreView.AppendLine("<form method=\"POST\">");
                pizzaSuggestionPreView.AppendLine($"<div class=\"radio\"><label><input type = \"radio\" name=\"pizzaVote\" value=\"up\">Up</label></div>");
                pizzaSuggestionPreView.AppendLine($"<div class=\"radio\"><label><input type = \"radio\" name=\"pizzaVote\" value=\"down\">Down</label></div>");
                pizzaSuggestionPreView.AppendLine($"<input type=\"hidden\" name=\"pizzaid\" value=\"{pizza.Id}\" />");
                pizzaSuggestionPreView.AppendLine("<input type=\"submit\" class=\"btn btn-primary\" value=\"Vote\" />");
                pizzaSuggestionPreView.AppendLine("</form>");
                pizzaSuggestionPreView.AppendLine("</div>");
                pizzaSuggestionPreView.AppendLine("</div>");
            }
            pizzaSuggestionPreView.AppendLine("</div>");
            return pizzaSuggestionPreView.ToString();
        }
    }
}