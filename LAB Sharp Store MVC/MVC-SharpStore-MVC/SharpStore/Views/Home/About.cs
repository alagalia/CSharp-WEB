using MVC.Interfaces;

namespace SharpStore.Views.Home
{
    public class About : IRenderable
    {
        public string Render()
        {
            return WebUtils.RetriveContentPathFolder(Constants.HomeAbout);
        }
    }
}