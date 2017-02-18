using System.Text;
using SimpleMVC.App.MVC.Interfaces.Generic;
using SimpleMVC.App.ViewModels;

namespace SimpleMVC.App.Views.Users
{
    public class All :IRenderable<AllUsernamesViewModel>
    {
        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h3>All users</h3>");
            sb.AppendLine("<ul>");
            foreach (string username in Model.Usernames)
            {
                sb.AppendLine($"<li>{username}</li>");
            }
            sb.AppendLine("</ul>");
            return sb.ToString();
        }

        public AllUsernamesViewModel Model { get; set; }
    }
}