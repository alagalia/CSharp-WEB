using System.ComponentModel.DataAnnotations;
using PizzaMVCApp.Models;

namespace PizzaMVCApp.BindingModels
{
    public class AddPizzaBindinModel
    {
        public string Title { get; set; }

        public string Recipe { get; set; }

        public string ImageUrl { get; set; }

    }
}