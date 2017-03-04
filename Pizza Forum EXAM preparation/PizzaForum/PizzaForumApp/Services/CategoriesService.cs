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
            CategoryEditViewModel model = new CategoryEditViewModel { Category = category };
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

        public void DeleteCategoryinDb(int id)
        {
            Context.Categories.Remove(Context.Categories.Find(id));
            Context.SaveChanges();
        }

        public IEnumerable<HomeTopicsViewModel> GetAllCategoriesFromDbNotForAdminView(User user, int categoryId)
        {
            IEnumerable<HomeTopicsViewModel> model = null;
            Category category = Context.Categories.Find(categoryId);
            if (category != null)
            {
                model = category.Topics.Select(
                   t => new HomeTopicsViewModel()
                   {
                       Title = t.Title,
                       Author = t.Author,
                       Category = t.Category,
                       PublushDate = t.PublishDate,
                       RepliesCount = t.Replies.Count
                   });
            }
            return model;
        }
    }
}