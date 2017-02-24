using System.Collections.Generic;
using System.Linq;
using SharpStore.Data;
using SharpStore.ViewModels;

namespace SharpStore.Services
{
    public class KnivesService : Service
    {
        public KnivesService(SharpStoreContext2 context) : base(context)
        {
        }

        public IEnumerable<ProductViewModel> GetProducts(string name)
        {
            var knives = this.Context.Knives.Where(k=>k.Name.Contains(name)).ToArray();
            List<ProductViewModel> productsViewModelsmodels = new List<ProductViewModel>();
            foreach (var knife in knives)
            {
                productsViewModelsmodels.Add(new ProductViewModel()
                {
                    Id=knife.Id,
                    Name = knife.Name,
                    Price = knife.Price,
                    ImageUrl = knife.ImageUrl
                });
            }
            return productsViewModelsmodels;
        }
        public IEnumerable<ProductViewModel> GetProducts()
        {
            var knives = Context.Knives.ToArray();
            List<ProductViewModel> productsViewModelsmodels = new List<ProductViewModel>();
            foreach (var knife in knives)
            {
                productsViewModelsmodels.Add(new ProductViewModel()
                {
                    Id = knife.Id,
                    Name = knife.Name,
                    Price = knife.Price,
                    ImageUrl = knife.ImageUrl
                });
            }
            return productsViewModelsmodels;
        }

    }
}