using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using PizzaMVCApp.Models;

namespace PizzaMVCApp.ViewModels
{
    public class PizzaViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Recipe { get; set; }

        public string ImageUrl { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }

        public int OwnerId { get; set; }

        public override string ToString()
        {
            return
                $@"<h3>{this.Title}</h3>
			<img src=""{this.ImageUrl}"" width=""300px""/>
			<p>{this.Recipe}</p>
			<p>Up: {this.UpVotes}</p>
			<p>Down: {this.DownVotes}</p>";
        }
    }
}