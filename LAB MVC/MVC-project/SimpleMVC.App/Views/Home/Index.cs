using System.Text;
using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.Views.Home
{
    public class Index : IRenderable
    {
        public string Render()
        {
            StringBuilder sb=  new StringBuilder("<h2>HELLO MVC</h2>");
            return sb.ToString();
        }
    }
}
