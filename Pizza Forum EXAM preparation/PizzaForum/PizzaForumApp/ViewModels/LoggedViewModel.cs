using PizzaForumApp.Models;

namespace PizzaForumApp.ViewModels
{
    public abstract class LoggedViewModel
    {
        public User User { get; set; }
    }
}