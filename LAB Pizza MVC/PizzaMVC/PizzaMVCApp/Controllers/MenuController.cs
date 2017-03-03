using PizzaMVCApp.Security;
using PizzaMVCApp.Services;
using PizzaMVCApp.ViewModels;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace PizzaMVCApp.Controllers
{
    public class MenuController : Controller
    {
        private SignInManager signInManager;

        public MenuController()
        {
            this.signInManager = new SignInManager(Data.Data.Context);
        }

        [HttpGet]
        public IActionResult<SuggestionViewModel> Index()
        {
            PizzaService serv = new PizzaService(Data.Data.Context);
            SuggestionViewModel model = serv.GetAllPizzas();
            return View(model);
        }
    }
}