using System;
using System.Collections.Generic;
using MVC.Attributes.Methods;
using MVC.Controllers;
using MVC.Interfaces;
using MVC.Interfaces.Generic;
using SharpStore.BindingModels;
using SharpStore.Models;
using SharpStore.Services;
using SharpStore.ViewModels;
using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;

namespace SharpStore.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult About()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return this.View();
        }
        
        [HttpPost]
        public IActionResult Contacts(MessageBindinModel messageBinfingModel)
        {
            
            if (string.IsNullOrEmpty(messageBinfingModel.Email) || string.IsNullOrEmpty(messageBinfingModel.Subject))
            {
                Console.WriteLine( "REDIRECT");
                this.Redirect(new HttpResponse()
                {
                }, "/home/contacts");
            }
            MessageService service = new MessageService(Data.Data.Context);
            service.AddMessageFromBind(messageBinfingModel);
            return this.View("Home","Index");
        }

        [HttpGet]
        public IActionResult<IEnumerable<ProductViewModel>> Products()
        {
            var service = new KnivesService(Data.Data.Context);
            var models = service.GetProducts();
            return this.View(models);
        }

        [HttpGet]
        public IActionResult<IEnumerable<ProductViewModel>> Products(string name)
        {
            var service = new KnivesService(Data.Data.Context);
            var models = service.GetProducts(name);
            return this.View(models);
        }

        [HttpGet]
        public IActionResult<ProductViewModel> Buy() //todo string kinfieId
        {
            PurchaseService service = new PurchaseService(Data.Data.Context);
            var knife = service.GetKnifeById(1); //todo repleace 1 with knifeId
            return this.View(knife);
        }

        [HttpPost]
        public IActionResult Buy(PurchaseBindingModel purchaseBindingModel)
        {
            PurchaseService service = new PurchaseService(Data.Data.Context);
            service.AddPurchaseToDb(purchaseBindingModel);
             
        }
    }
}
