using System.Collections;
using System.Collections.Generic;
using PizzaForumApp.BindingModels;
using PizzaForumApp.Models;
using PizzaForumApp.Security;
using PizzaForumApp.Services;
using PizzaForumApp.ViewModels;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace PizzaForumApp.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoriesService service;

        public CategoriesController()
        {
            this.service = new CategoriesService();
        }

        [HttpGet]
        public IActionResult<CategoriesAllViewModel> All(HttpSession session, HttpResponse response)
        {
            User activeUser = GetAuthenticatedUser(session, response);
            CategoriesAllViewModel model = service.GetAllCategoriesFromDB(activeUser);
            return this.View(model);
        }

        [HttpGet]
        public IActionResult New(HttpSession session, HttpResponse response)
        {
            GetAuthenticatedUser(session, response);
            return this.View();
        }

        [HttpPost]
        public void New(HttpSession session, HttpResponse response, CategoriesNewBindingModel bindingModel)
        {
           GetAuthenticatedUser(session, response);

            if (string.IsNullOrEmpty(bindingModel.CategoryName))
            {
                this.Redirect(response, "/categories/new");

            }
            service.AddCategoryToDb(bindingModel);
            this.Redirect(response, "/categories/all");
        }

        [HttpGet]
        public IActionResult<CategoryEditViewModel> Edit(HttpSession session, HttpResponse response, int Id)
        {
            GetAuthenticatedUser(session, response);
            CategoryEditViewModel name = service.GetCategoryName(Id);
            return this.View(name);

        }

        [HttpPost]
        public void Edit(HttpSession session, HttpResponse response, CategoriesEditBindingModel category)
        {
            GetAuthenticatedUser(session, response);
            service.EditCategoryName(category);
            this.Redirect(response, "/categories/all");
        }

        [HttpGet]
        public void Delete(HttpSession session, HttpResponse response, int id)
        {
            GetAuthenticatedUser(session, response);
            service.DeleteCategoryinDb(id);
            this.Redirect(response, "/categories/all");
        }

        private User GetAuthenticatedUser(HttpSession session, HttpResponse response)
        {
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/forum/login");
            }
            User activeUser = AuthenticationManager.GetAuthenticateduser(session.Id);
            if (!activeUser.IsAdimn)
            {
                this.Redirect(response, "/home/topics");
            }
            return activeUser;
        }

        [HttpGet]
        public IActionResult<IEnumerable<HomeTopicsViewModel>> Topics(HttpSession session, HttpResponse response, int categoryId)
        {
            User user = GetAuthenticatedUser(session, response);
            IEnumerable<HomeTopicsViewModel> model = service.GetAllCategoriesFromDbNotForAdminView(user, categoryId);
            return this.View(model);
        }
    }
}
