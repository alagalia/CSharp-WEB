using System;
using System.Collections.Generic;
using System.Text;
using MVC.Interfaces.Generic;
using SharpStore.ViewModels;

namespace SharpStore.Views.Home
{
    public class Products : IRenderable<IEnumerable<ProductViewModel>>
    {
        public IEnumerable<ProductViewModel> Model { get; set; }

        public string Render()
        {
            string template = WebUtils.RetriveContentPathFolder(Constants.HomeProducts);
            StringBuilder productsBuilder = new StringBuilder();
            foreach (var knife in this.Model)
            {
                productsBuilder.AppendLine(knife.ToString());

            }
            return String.Format(template, productsBuilder);
        }

    }
}