using System.Collections.Generic;
using System.Linq;
using PizzaForumApp.BindingModels;
using PizzaForumApp.Models;
using PizzaForumApp.ViewModels;

namespace PizzaForumApp.Services
{
    public class CategoriesService : Service
    {
        public CategoriesAllViewModel GetAllCategoriesFromDB(User activeUser)
        {
            CategoriesAllViewModel categoriesAllViewModel = new CategoriesAllViewModel
            {
                User = activeUser
            };

            IEnumerable<CategorySectionViewModel> categoriesModels = Context.Categories
                .Select(c => new CategorySectionViewModel()
                {
                    CategoryId = c.Id,
                    CategoryName = c.Name
                });
            categoriesAllViewModel.CategoriesModels = categoriesModels;
            return categoriesAllViewModel;
        }

        public void AddCategoryToDb(CategoriesNewBindingModel model)
        {
            Context.Categories.Add(new Category()
            {
                Name = model.CategoryName
            });
            Context.SaveChanges();
        }

        public CategoryEditViewModel GetCategoryName(int id)
        {
            Category category = Context.Categories.FirstOrDefault(c => c.Id == id);
            CategoryEditViewModel model = new CategoryEditViewModel {Category = category};
            return model;
        }

        public void EditCategoryName(CategoriesEditBindingModel categoryEditBindingModel)
        {
            Category searchedCategory = Context.Categories.FirstOrDefault(c => c.Id == categoryEditBindingModel.CategoryId);
            if (searchedCategory != null)
            {
                searchedCategory.Name = categoryEditBindingModel.CategoryName;
                Context.SaveChanges();
            }
        }
    }
}