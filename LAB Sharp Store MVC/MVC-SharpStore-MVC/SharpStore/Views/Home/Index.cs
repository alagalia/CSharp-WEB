using System.IO;
using MVC.Interfaces;

namespace SharpStore.Views.Home
{
    public class Index : IRenderable
    {
        public string Render()
        {
            return WebUtils.RetriveContentPathFolder(Constants.HomeIndex);
            //return File.ReadAllText("../../content/home.html");
        }
    }
}
