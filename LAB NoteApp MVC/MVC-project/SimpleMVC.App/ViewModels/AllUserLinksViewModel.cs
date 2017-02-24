using System.Collections.Generic;
using SimpleMVC.App.Models;

namespace SimpleMVC.App.ViewModels
{
    public class AllUserLinksViewModel
    {
        public AllUserLinksViewModel()
        {
            this.nameIdDictionary = new Dictionary<int, string>();
        }
        public IDictionary<int, string> nameIdDictionary;
    }
}