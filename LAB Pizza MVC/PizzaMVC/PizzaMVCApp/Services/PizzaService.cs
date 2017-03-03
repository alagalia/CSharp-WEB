using System;
using System.Linq;
using PizzaMVCApp.BindingModels;
using PizzaMVCApp.Data;
using PizzaMVCApp.Models;
using PizzaMVCApp.ViewModels;
using SimpleHttpServer.Models;

namespace PizzaMVCApp.Services
{
    public class PizzaService : Service
    {
        public PizzaService(PizzaContext context) : base(context)
        {
        }

        public YourSuggestionsViewModel GetPizzasByUser(string id)
        {
            YourSuggestionsViewModel model = new YourSuggestionsViewModel();
            var currentSessionFromDb = Context.Sessions.FirstOrDefault(s => s.SessionId == id);
            if (currentSessionFromDb != null)
            {
                User currentUser = currentSessionFromDb.User;
                model.Email = currentUser.Email;
                foreach (var pizza in currentUser.PizzaSuggestions)
                {
                    model.YourSuggestedPizzas.Add(new PizzaViewModel()
                    {
                        Title = pizza.Title,
                        Recipe = pizza.Recipe,
                        ImageUrl = pizza.ImageUrl,
                        UpVotes = pizza.UpVotes,
                        DownVotes = pizza.DownVotes,
                        OwnerId = pizza.Owner.Id
                    });
                }
                return model;
            }
            return null;
        }

        public void AddPizzaToDB(AddPizzaBindinModel model, string id)
        {
            var currentUser = Context.Sessions.FirstOrDefault(s => s.SessionId == id).User;

            Pizza pizza = new Pizza()
            {
                Title = model.Title,
                Recipe = model.Recipe,
                ImageUrl = model.ImageUrl,
                Owner = currentUser
            };
            Context.Pizzas.Add(pizza);
            Context.SaveChanges();
        }

        public SuggestionViewModel GetAllPizzas()
        {
            SuggestionViewModel model = new SuggestionViewModel();
            var pizzas = Context.Pizzas.ToList();
                foreach (var pizza in pizzas)
                {
                    model.PizzaSuggestions.Add(new PizzaViewModel()
                    {
                        Title = pizza.Title,
                        Recipe = pizza.Recipe,
                        ImageUrl = pizza.ImageUrl,
                        UpVotes = pizza.UpVotes,
                        DownVotes = pizza.DownVotes,
                        OwnerId = pizza.Owner.Id
                    });
                }
                return model;
        }
    }
}