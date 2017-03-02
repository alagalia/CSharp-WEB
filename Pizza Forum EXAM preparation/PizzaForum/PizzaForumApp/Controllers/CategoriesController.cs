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
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }
            User activeUser = AuthenticationManager.GetAuthenticateduser(session.Id);
            if (!activeUser.IsAdimn)
            {
                this.Redirect(response, "/home/topics");
                return null;
            }

            CategoriesAllViewModel model = service.GetAllCategoriesFromDB(activeUser);
            return this.View(model);
        }

        [HttpGet]
        public IActionResult New(HttpSession session, HttpResponse response)
        {
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }
            User activeUser = AuthenticationManager.GetAuthenticateduser(session.Id);
            if (!activeUser.IsAdimn)
            {
                this.Redirect(response, "/home/topics");
                return null;
            }
            return this.View();
        }

        [HttpPost]
        public void New(HttpSession session, HttpResponse response, CategoriesNewBindingModel bindingModel)
        {
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/forum/login");
                return;
            }
            User activeUser = AuthenticationManager.GetAuthenticateduser(session.Id);
            if (!activeUser.IsAdimn)
            {
                this.Redirect(response, "/home/topics");
                return;
            }

            service.AddCategoryToDb(bindingModel);
            this.Redirect(response, "/categories/all");
        }

        [HttpGet]
        public IActionResult<CategoryEditViewModel> Edit(HttpSession session, HttpResponse response, int Id)
        {
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }
            User activeUser = AuthenticationManager.GetAuthenticateduser(session.Id);
            if (!activeUser.IsAdimn)
            {
                this.Redirect(response, "/home/topics");
                return null;
            }
            CategoryEditViewModel name = service.GetCategoryName(Id);
            return this.View(name);

        }

        [HttpPost]
        public void Edit(HttpSession session, HttpResponse response, CategoriesEditBindingModel categoryEditBindingModel)
        {
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/forum/login");
                return;
            }
            User activeUser = AuthenticationManager.GetAuthenticateduser(session.Id);
            if (!activeUser.IsAdimn)
            {
                this.Redirect(response, "/home/topics");
                return;
            }
            service.EditCategoryName(categoryEditBindingModel);
            this.Redirect(response, "/categories/all");


        }
    }
}
