using System;

namespace ExamApp.BindingModels
{
    public class AddGameBindingViewModel
    {
        public string Title { get; set; } 
        public string Description { get; set; } 
        public string Thumbnail { get; set; } 
        public double Price { get; set; } 
        public double Size { get; set; }
        public string Trailer { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}