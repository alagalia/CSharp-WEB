namespace ExamApp.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageThumbnail { get; set; }
        public double Size { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            string description = this.Description.Substring(0, 300);
            string pattern =
                $@" <div class=""card col-4 thumbnail"">

                        <img class=""card-image-top img-fluid img-thumbnail"" src=""{this.ImageThumbnail}"">

                        <div class=""card-block"">
                            <h4 class=""card-title"">{
                    this.Title}</h4>
                            <p class=""card-text""><strong>Price</strong> - {this.Price:F2}&euro;</p>
                            <p class=""card-text""><strong>Size</strong> - {this.Size:F2} GB</p>
                            <p class=""card-text"">{description}</p>
                        </div>

                        <div class=""card-footer"">
                            <a class=""card-button btn btn-outline-primary"" name=""info"" href=""/home/info?Id={this.Id}"">Info</a>
                        </div></div>";
            return pattern;
        }
    }
}