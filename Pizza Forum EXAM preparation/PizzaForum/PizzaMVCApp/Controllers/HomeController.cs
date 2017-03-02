using PizzaMVCApp.Security;
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
            //todo chek if is correct instead new PizzaContext
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
    }
}