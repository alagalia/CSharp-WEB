using PizzaMVCApp.BindingModels;
using PizzaMVCApp.Models;
using PizzaMVCApp.Security;
using PizzaMVCApp.Services;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;

namespace PizzaMVCApp.Controllers
{
    public class UsersController : Controller
    {
        private SignInManager signInManager;

        public UsersController()
        {
            this.signInManager = new SignInManager(Data.Data.Context);
        }

        //SignIn section
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SignInBidingModel model, HttpSession session)
        {
            UserService userService = new UserService(Data.Data.Context);
            var user = userService.SignInUser(model);
            if (user != null)
            {
                SessionService sessionService = new SessionService(Data.Data.Context);
                sessionService.AddUserSession(user, session);
                return this.View("Home", "IndexLogged");
            }
            return View();
        }


        //SignUp section
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpBindinModel model)
        {
            UserService service = new UserService(Data.Data.Context);
            service.SignUpUser(model);
            return this.View("Home", "Index");
        }

        //LogOut section
        [HttpGet]
        public IActionResult LogOut(HttpSession session)
        {
            this.signInManager.LogOut(session);
            return this.View("Home", "Index");
        }   
    }
}