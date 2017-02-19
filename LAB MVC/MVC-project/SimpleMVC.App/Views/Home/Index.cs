using System.Text;
using SimpleMVC.App.MVC.Interfaces;
using SimpleMVC.App.Views.Users;

namespace SimpleMVC.App.Views.Home
{
    public class Index : IRenderable
    {
        public string Render()
        {
            StringBuilder sb =  new StringBuilder("<h2>NotesApp</h2>");
            sb.AppendLine("<li><a href=\"/home/users/all\">All users<a/></li>");
            sb.AppendLine("<li><a href=\"/home/users/register\">Register user</a></li>");
            return sb.ToString();
        }
    }
}
