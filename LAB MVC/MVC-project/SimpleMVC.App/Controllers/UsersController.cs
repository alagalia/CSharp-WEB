using System.Collections.Generic;
using System.Linq;
using SimpleMVC.App.BindingModels;
using SimpleMVC.App.Data;
using SimpleMVC.App.Models;
using SimpleMVC.App.MVC.Attributies.Methods;
using SimpleMVC.App.MVC.Controllers;
using SimpleMVC.App.MVC.Interfaces;
using SimpleMVC.App.MVC.Interfaces.Generic;
using SimpleMVC.App.ViewModels;

namespace SimpleMVC.App.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            //add user to DB
            var newUser = new User()
            {
                UserName = model.Username,
                Password = model.Password
            };

            using (var context = new NoteAppContext())
            {
                context.Users.Add(newUser);
                context.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public IActionResult<AllUsernamesViewModel> All()
        {
            List<string> names = null;
            using (var context = new NoteAppContext())
            {
                names = context.Users.Select(u => u.UserName).ToList();
            }

            var viewModel = new AllUsernamesViewModel()
            {
                Usernames = names
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id)
        {
            using (var context = new NoteAppContext())
            {
                var user = context.Users.Find(id);

                var viewModel = new UserProfileViewModel()
                {
                    UserId = id,
                    Username = user.UserName,
                    Notes = user.Notes
                        .Select(n =>
                        new NoteViewModel()
                        {
                            Content = n.Content,
                            Title = n.Title
                        })
                };
                return View(viewModel);
            }
        }

        [HttpPost]
        public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model)
        {
            using (var context = new NoteAppContext())
            {
                var user = context.Users.Find(model.UserId);

                var note = new Note()
                {
                    Title = model.Title,
                    Content = model.Content,
                    Owner = user
                };
                context.Notes.Add(note);
                context.SaveChanges();
            };
            return Profile(model.UserId);
        }
    }
}