using ExamApp.BindingModels;
using ExamApp.Models;
using ExamApp.Security;
using ExamApp.Services;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;

namespace ExamApp.Controllers
{
    public class UserController : Controller
    {
        private UserService service;

        public UserController()
        {
            this.service = new UserService();
        }

        [HttpGet]
        public IActionResult Register(HttpSession session, HttpResponse response)
        {
            if (AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/home/all");
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
                Redirect(response, "/user/login");
                return;
            }
            Redirect(response, "/user/register");
        }


        [HttpGet]
        public IActionResult Login(HttpSession session, HttpResponse response)
        {
            if (AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/home/all");
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
                Redirect(response, "/home/all"); 
                return;
            }
            Redirect(response, "/user/login");
        }

        [HttpGet]
        public void Logout(HttpResponse response, HttpSession session)
        {
            AuthenticationManager.Logout(response, session.Id);
            this.Redirect(response, "/user/login");
        }
    }
}