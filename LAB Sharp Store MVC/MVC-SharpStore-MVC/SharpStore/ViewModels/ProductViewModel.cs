using System.Text;

namespace SharpStore.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public override string ToString()
        {
            StringBuilder kniveBuilder = new StringBuilder();
            kniveBuilder.Append("<div class=\"col-sm-4\">\r\n" +
                                        "<div class=\"thumbnail\">\r\n" +
                                            $"<img src=\"{this.ImageUrl}\" alt=\"...\">\r\n " +
                                            "<div class=\"caption\">\r\n " +
                                                $"<h3>{this.Name}</h3>\r\n" +
                                                $"<p>${this.Price}</p>\r\n" +
                                                $@"<a href=""/home/buy?knifeId={this.Id}"" class=""btn btn-primary"">Buy now</a>" +
                                            //"<button type=\"button\" class=\"btn btn-primary \">Buy Now</button>\r\n" +
                                            "</div>\r\n" +
                                          "</div>\r\n" +
                                         "</div>");
            return kniveBuilder.ToString();
        }
    }
}