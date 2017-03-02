using PizzaForumApp.BindingModels;
using PizzaForumApp.Data;
using PizzaForumApp.Models;

namespace PizzaForumApp.Services
{
    public abstract class Service
    {
        public PizzaForumContext Context;
        
        protected Service()
        {
            this.Context = Data.Data.Context;
        }

        
    }
}