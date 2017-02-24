using MVC.Interfaces;
using MVC.Interfaces.Generic;
using SharpStore.ViewModels;

namespace SharpStore.Views.Home
{
    public class Buy :IRenderable<ProductViewModel>
    {
        public ProductViewModel Model { get; set; }

        public string Render()
        {
            string template =  WebUtils.RetriveContentPathFolder(Constants.HomeBuy);
            return string.Format(template, Model);
        }
    }
}