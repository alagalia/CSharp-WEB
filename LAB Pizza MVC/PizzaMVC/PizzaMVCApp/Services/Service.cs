using PizzaMVCApp.Data;

namespace PizzaMVCApp.Services
{
    public abstract class Service
    {
        public PizzaContext Context;

        protected Service(PizzaContext context)
        {
            this.Context = context;
        }

    }
}