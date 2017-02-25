namespace PizzaMVCApp.Data
{
    public class Data
    {
        private static PizzaContext context;

        public static PizzaContext Context => context ?? (context = new PizzaContext());
    }
}