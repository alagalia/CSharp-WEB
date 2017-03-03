using PizzaMVCApp.Models;
using PizzaMVCApp.Security;
using PizzaMVCApp.Services;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;

namespace PizzaMVCApp.Controllers
{
    public class HomeController :Controller
    {
        private SignInManager signInManager;

        public HomeController()
        {
            this.signInManager = new SignInManager(Data.Data.Context);
        }

        
        [HttpGet]
        public IActionResult Index(HttpSession session)
        {

            if (this.signInManager.IsAuthenticated(session))
            {
                return this.View("Home", "IndexLogged");
            }
            return View();
        }

        [HttpGet]
        public IActionResult IndexLogged(HttpSession session)
        {
            return View();
        }
    }
}