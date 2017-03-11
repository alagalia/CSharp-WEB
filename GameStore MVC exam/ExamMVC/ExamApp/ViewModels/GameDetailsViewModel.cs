using System;

namespace ExamApp.ViewModels
{
    public class GameDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Trailer { get; set; }
        public string ImageThumbnail { get; set; }
        public double Size { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public override string ToString()
        {
            string description = this.Description.Substring(0, 300);

            string pattern =
                $@"<h1 class=""display-3"">{this.Title}</h1>
                <br/>

                <iframe width=""560"" height=""315"" src=""https://www.youtube.com/embed/{this.Trailer}"" frameborder=""0"" allowfullscreen></iframe>

                <br/>
                <br/>

                <p>{description}</p>

                <p><strong>Price</strong> - {this.Price:F2}&euro;</p>
                <p><strong>Size</strong> - {this.Size:F2} GB</p>
                <p><strong>Release Date</strong> - {this.ReleaseDate}</p>

                <a class=""btn btn-outline-primary"" name=""back"" href=""/home/all"">Back</a>
                <form action=""/home/buy?gameId={this.Id}"" method=""post"">
                    <input type=""number"" name=""GameId""value=""{this.Id}"" hidden=""hidden"" />
                    <br/>
                    <input type=""submit"" class=""btn btn-success"" value=""Buy"" />
                </form>
                <br/>
                <br/>";

            return pattern;
        }
    }
}