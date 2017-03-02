using System.Collections.Generic;
using PizzaForumApp.Models;

namespace PizzaForumApp.ViewModels
{
    public class CategoriesAllViewModel : LoggedViewModel
    {
        public IEnumerable<CategorySectionViewModel> CategoriesModels { get; set; }
    }
}
