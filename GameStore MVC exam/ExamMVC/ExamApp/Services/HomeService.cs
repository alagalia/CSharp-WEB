using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text.RegularExpressions;
using ExamApp.BindingModels;
using ExamApp.Models;
using ExamApp.ViewModels;

namespace ExamApp.Services
{
    public class HomeService : Service
    {
        public AllGamesViewModel GetAllGames(string loggedUserEmail)
        {
            ICollection<GameViewModel> games = this.Context.Games.Select(g => new GameViewModel()
            {
                Id = g.Id,
                Title = g.Title,
                Description = g.Description,
                ImageThumbnail = g.ImageThumbnail,
                Price = g.Price,
                Size = g.Size
            }).ToList();

            return ReturnGamesViewModel(loggedUserEmail, games);
        }
        
        public GameDetailsViewModel GetGame(int id)
        {
            Game game = this.Context.Games.Find(id);
            GameDetailsViewModel model = new GameDetailsViewModel()
            {
                Id = game.Id,
                Description = game.Description,
                ImageThumbnail = game.ImageThumbnail,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate,
                Size = game.Size,
                Title = game.Title,
                Trailer = game.Trailer
            };
            return model;
        }

        public AllGamesViewModel GetOwnedGames(string loggedUserEmail)
        {
            User user = this.Context.Users.FirstOrDefault(u => u.Email == loggedUserEmail);
            ICollection<GameViewModel> games = user.Games.Select(g => new GameViewModel()
            {
                Id = g.Id,
                Title = g.Title,
                Description = g.Description,
                ImageThumbnail = g.ImageThumbnail,
                Price = g.Price,
                Size = g.Size
            }).ToList();

            return ReturnGamesViewModel(loggedUserEmail, games);
        }

        private static AllGamesViewModel ReturnGamesViewModel(string loggedUserEmail, ICollection<GameViewModel> games)
        {
            LoggedUserViewModel loggedUserViewModel = new LoggedUserViewModel()
            {
                Email = loggedUserEmail
            };
            AllGamesViewModel model = new AllGamesViewModel();
            model.LoggedUserViewModel = loggedUserViewModel;
            model.Games = games;
            return model;
        }

        internal void BuyGame(int id, int loggedUserId)
        {
            Game game = this.Context.Games.Find(id);
            User user = this.Context.Users.Find(loggedUserId);
            user.Games.Add(game);
            this.Context.SaveChanges();
        }

        public AllAdminGamesViewModel GetAllGamesAsAdmin()
        {
            IEnumerable<AdminGameViewModel> gameCollection = this.Context.Games.Select(g => new AdminGameViewModel()
            {
                Id = g.Id,
                Price = g.Price,
                Size = g.Size,
                Title = g.Title
            });
            AllAdminGamesViewModel model = new AllAdminGamesViewModel()
            {
                Model = gameCollection
            };
            return model;
        }

        public void AddGameToDb(AddGameBindingViewModel bindModel)
        {
            if (BindingModelIsvalid(bindModel))
            {
                
            }
            Game game = new Game()
            {
                Description = bindModel.Description,
                ImageThumbnail = bindModel.Thumbnail,
                Price = bindModel.Price,
                ReleaseDate = bindModel.ReleaseDate,
                Size = bindModel.Size,
                Title = bindModel.Title,
                Trailer = bindModel.Trailer
            };
            this.Context.Games.Add(game);
            this.Context.SaveChanges();
        }

        private bool BindingModelIsvalid(AddGameBindingViewModel bindModel)
        {
            if (!char.IsUpper(bindModel.Title[0]) || bindModel.Title.Length < 3 || bindModel.Title.Length > 100)
            {
                return false;
            }
            if (bindModel.Price <= 0 || bindModel.Size <=0)
            {
                return false;
            }
            string trailer = bindModel.Trailer.Substring(bindModel.Trailer.IndexOf("/"));
            if (trailer.Length != 11)
            {
                return false;
            }
            string pattern = @"http:\/{2}|https:\/{2}";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(bindModel.Thumbnail))
            {
                return false;
            }
            if (bindModel.Description.Length<20)
            {
                return false;
            }
            return true;
        }

        public void EditGameToDb(EditGameBindingViewModel bindModel)
        {
            Game game = this.Context.Games.Find(bindModel.Id);
            game.Title = bindModel.Title;
            game.Description = bindModel.Description;
            game.ImageThumbnail = bindModel.ImageThumbnail;
            game.Price = bindModel.Price;
            game.Size = bindModel.Size;
            game.Trailer = bindModel.Trailer;
            this.Context.Games.AddOrUpdate(game);
        }

        public void DeleteGameInDb(int id)
        {
            this.Context.Games.Remove(this.Context.Games.Find(id));
            Context.SaveChanges();
        }
    }
}