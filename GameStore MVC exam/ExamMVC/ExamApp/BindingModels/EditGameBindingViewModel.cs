namespace ExamApp.BindingModels
{
    public class EditGameBindingViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageThumbnail { get; set; }
        public double Price { get; set; }
        public double Size { get; set; }
        public string Trailer { get; set; }
    }
}