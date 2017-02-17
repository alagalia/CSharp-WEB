namespace Razor
{
    public class HomePage :Page
    {
        protected HomePage(string htmlPath) : base(htmlPath)
        {

        }

        public HomePage() :
            this("../../content/home.html")
        {
            this.AddStyleByPath("bootstrap/css/bootstrap.min.css");
            this.AddStyleByPath("content/css/carousel.css");
        }
    }
}