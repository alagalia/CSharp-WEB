using System.IO;
using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.Views.Home
{
    public class Site : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/home.html");
        }
    }
}