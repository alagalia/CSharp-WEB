using System.Collections.Generic;
using System.Text;

namespace ExamApp.ViewModels
{
    public class AllAdminGamesViewModel
    {
        public IEnumerable<AdminGameViewModel> Model { get; set; }
        public override string ToString()
        {
            StringBuilder allAdmingames = new StringBuilder();
            foreach (AdminGameViewModel game in Model)
            {
                allAdmingames.AppendLine(game.ToString());
            }

            return allAdmingames.ToString();
        }
    }
}