using PizzaForumApp.BindingModels;
using PizzaForumApp.Models;
using PizzaForumApp.Security;
using PizzaForumApp.Services;
using PizzaForumApp.Utillities;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;

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

        //[HttpGet]
        //public IActionResult Index(HttpSession session)
        //{
        //    if (this.signInManager.IsAuthenticated(session))
        //    {
        //        return this.View("Home", "IndexLogged");
        //    }

        //    return View();
        //}

    }
}