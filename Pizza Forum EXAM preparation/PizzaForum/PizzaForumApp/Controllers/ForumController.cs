using PizzaForumApp.BindingModels;
using PizzaForumApp.Models;
using PizzaForumApp.Security;
using PizzaForumApp.Services;
using PizzaForumApp.Utillities;
using PizzaForumApp.ViewModels;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace PizzaForumApp.Controllers
{
    public class ForumController :Controller
    {
        private ForumService service;

        public ForumController()
        {
            this.service = new ForumService();
        }

        [HttpGet]
        public IActionResult Register(HttpSession session, HttpResponse response)
        {
            if (AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/home/topics");
                return null;
            }
            return this.View();
        }

        [HttpPost]
        public void Register(HttpResponse response, RegisterBindingModel model)
        {
            if (service.IsRegisterBidingModelValid(model))
            {
                service.RegisterUser(model);
                Redirect(response, "/forum/login");
                return;
            }
            Redirect(response, "/forum/register");
        }

        [HttpGet]
        public IActionResult Login(HttpSession session, HttpResponse response)
        {
            if (AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/home/topics");
                return null;
            }
            return this.View();
        }

        [HttpPost]
        public void Login(HttpResponse response, HttpSession session, LoginBidingModel model)
        {
            if (service.IsLoginBidingModelValid(model))
            {
                User user = service.GetuserFromLoginBind(model);
                service.LogInUser(user, session.Id);
                Redirect(response, "/home/topics"); 
                return;
            }
            Redirect(response, "/forum/login");
        }

        [HttpGet]
        public void Logout(HttpResponse response, HttpSession session)
        {
            AuthenticationManager.Logout(response, session.Id);
            this.Redirect(response, "/home/topics");
        }

        [HttpGet]
        public IActionResult<ForumUserProfileViewModel> Profile(HttpSession session, HttpResponse response, int id)
        {
            User loggedUser = AuthenticationManager.GetAuthenticateduser(session.Id);
            
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/home/topics");
                return null;
            }
            ForumUserProfileViewModel model = service.GetUserInfoFromDb(id, loggedUser.Id);
            return this.View(model);
        }

    }
}