using System.Collections.Generic;
using System.Text;

namespace ExamApp.ViewModels
{
    public class AllGamesViewModel
    {
        public LoggedUserViewModel LoggedUserViewModel { get; set; }

        public ICollection<GameViewModel> Games { get; set; }

        public override string ToString()
        {
            string startCardGroup = @"<div class=""card-group"">";
            string endCardGroup = @"</div>";

            StringBuilder gamesInCardgroups = new StringBuilder();
            gamesInCardgroups.AppendLine(startCardGroup);

            int counter = 0;
            foreach (GameViewModel game in Games)
            {
                if (counter == 3)
                {
                    gamesInCardgroups.AppendLine(endCardGroup);
                    gamesInCardgroups.AppendLine(startCardGroup);
                    counter = 0;
                }
                gamesInCardgroups.AppendLine(game.ToString());
                counter++;
            }
            gamesInCardgroups.AppendLine(endCardGroup);

            return gamesInCardgroups.ToString();
        }
    }
}