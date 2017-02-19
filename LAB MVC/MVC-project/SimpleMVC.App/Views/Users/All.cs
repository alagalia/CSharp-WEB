using System.Text;
using SimpleMVC.App.Models;
using SimpleMVC.App.MVC.Interfaces.Generic;
using SimpleMVC.App.ViewModels;

namespace SimpleMVC.App.Views.Users
{
    public class All :IRenderable<AllUserLinksViewModel>
    {
        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<a href=\"/home/index\">Home<a/>");
            sb.AppendLine("<h3>All users</h3>");
            sb.AppendLine("<ul>");
            foreach (var user in Model.nameIdDictionary)
            {
                sb.AppendLine($"<li><a href=\"/users/profile?id={user.Key}\">{user.Value}</a></li>");
            }
            sb.AppendLine("</ul>");
            return sb.ToString();
        }

        public AllUserLinksViewModel Model { get; set; }
    }
}