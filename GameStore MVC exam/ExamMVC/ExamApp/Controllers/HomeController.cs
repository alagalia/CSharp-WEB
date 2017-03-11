using ExamApp.BindingModels;
using ExamApp.Models;
using ExamApp.Security;
using ExamApp.Services;
using ExamApp.ViewModels;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace ExamApp.Controllers
{
    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            this.service = new HomeService();
        }

        [HttpGet]
        public IActionResult<AllGamesViewModel> All(HttpSession session, HttpResponse response)
        {
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/user/login");
                return null;
            }
            string loggedUserEmail = AuthenticationManager.GetAuthenticateduser(session.Id).Email;

            AllGamesViewModel model = this.service.GetAllGames(loggedUserEmail);
            return this.View(model);
        }

        [HttpGet]
        public IActionResult<GameDetailsViewModel> Info(HttpSession session, HttpResponse response, int id)
        {
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/user/login");
                return null;
            }
            GameDetailsViewModel model = this.service.GetGame(id);
            return this.View(model);
        }

        [HttpGet]
        public IActionResult<AllGamesViewModel> Owned(HttpSession session, HttpResponse response)
        {
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/user/login");
                return null;
            }
            string loggedUserEmail = AuthenticationManager.GetAuthenticateduser(session.Id).Email;
            AllGamesViewModel model = this.service.GetOwnedGames(loggedUserEmail);
            return this.View(model);
        }

        [HttpPost]
        public void Buy(HttpSession session, HttpResponse response, int gameId)
        {
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/user/login");
                return;
            }
            int loggedUserId = AuthenticationManager.GetAuthenticateduser(session.Id).Id;

            this.service.BuyGame(gameId, loggedUserId);
            this.Redirect(response, "/home/owned");
        }

        //TODO this part from below must be exctract into AdminController
        [HttpGet]
        public IActionResult<AllAdminGamesViewModel> Admin(HttpSession session, HttpResponse response)
        {
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/user/login");
                return null;
            }
            User loggedUserEmail = AuthenticationManager.GetAuthenticateduser(session.Id);
            if (!loggedUserEmail.IsAdmin)
            {
                this.Redirect(response, "/home/all");
                return null;
            }
            AllAdminGamesViewModel model = this.service.GetAllGamesAsAdmin();
            return this.View(model);
        }

        [HttpGet]
        public IActionResult Add(HttpSession session, HttpResponse response)
        {
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/user/login");
                return null;
            }
            User loggedUserEmail = AuthenticationManager.GetAuthenticateduser(session.Id);
            if (!loggedUserEmail.IsAdmin)
            {
                this.Redirect(response, "/home/all");
                return null;
            }
            return this.View();
        }

        [HttpPost]
        public void Add(HttpSession session, HttpResponse response, AddGameBindingViewModel bindModel)
        {
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/user/login");
                return;
            }
            User loggedUserEmail = AuthenticationManager.GetAuthenticateduser(session.Id);
            if (!loggedUserEmail.IsAdmin)
            {
                this.Redirect(response, "/home/all");
                return;
            }
            this.service.AddGameToDb(bindModel);
            this.Redirect(response, "/home/admin");
        }

        [HttpGet]
        public IActionResult<GameDetailsViewModel> Edit(HttpSession session, HttpResponse response, int id)
        {
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/user/login");
                return null;
            }
            User loggedUserEmail = AuthenticationManager.GetAuthenticateduser(session.Id);
            if (!loggedUserEmail.IsAdmin)
            {
                this.Redirect(response, "/home/all");
                return null;
            }
            GameDetailsViewModel game = this.service.GetGame(id);
            return this.View(game);
        }

        [HttpPost]
        public void Edit(HttpSession session, HttpResponse response, EditGameBindingViewModel bindModel)
        {
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/user/login");
                return;
            }
            User loggedUserEmail = AuthenticationManager.GetAuthenticateduser(session.Id);
            if (!loggedUserEmail.IsAdmin)
            {
                this.Redirect(response, "/home/all");
                return;
            }
            this.service.EditGameToDb(bindModel);
            this.Redirect(response, "/home/Info?Id="+bindModel.Id);
        }

        [HttpGet]
        public void Delete(HttpSession session, HttpResponse response, int id)
        {
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/user/login");
                return;
            }
            User loggedUserEmail = AuthenticationManager.GetAuthenticateduser(session.Id);
            if (!loggedUserEmail.IsAdmin)
            {
                this.Redirect(response, "/home/all");
                return;
            }
            this.service.DeleteGameInDb(id);
            this.Redirect(response, "/home/admin");
        }
    }
}