using PizzaMVCApp.Utillities;
using SimpleMVC.Interfaces;

namespace PizzaMVCApp.Views.Menu
{
    public class Add :IRenderable
    {
        public string Render()
        {
            return WebUtils.RetriveContentPathFolder(Constants.MenuAddPizza);
        }
    }
}