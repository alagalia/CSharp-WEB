using MVC.Interfaces;

namespace SharpStore.Views.Home
{
    public class Contacts : IRenderable
    {
        public string Render()
        {
            return WebUtils.RetriveContentPathFolder(Constants.HomeContacts);
        }
    }
}