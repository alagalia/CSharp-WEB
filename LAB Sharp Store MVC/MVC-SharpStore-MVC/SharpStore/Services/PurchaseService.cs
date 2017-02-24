using System;
using SharpStore.BindingModels;
using SharpStore.Data;
using SharpStore.Models;
using SharpStore.ViewModels;

namespace SharpStore.Services
{
    public class PurchaseService : Service
    {
        public PurchaseService(SharpStoreContext2 context) : base(context)
        {
        }

        public void AddPurchaseToDb(PurchaseBindingModel purchaseBindingModel)
        {
            //TODO check if model has to be PurchaseBindingModel or View
            Purchase purchase = new Purchase()
            {
                BuyerName =  purchaseBindingModel.BuyerName,
                BuyerAddress = purchaseBindingModel.BuyerAddress,
                DeliveryType = (Delivery)Enum.Parse(typeof(Delivery),purchaseBindingModel.DeliveryType),
                BuyerPhoneNumber = purchaseBindingModel.BuyerPhoneNumber
            };
            Context.Purchases.Add(purchase);
            Context.SaveChanges();
        }

        public ProductViewModel GetKnifeById(int knifeId)
        {
            var knife = Context.Knives.Find(knifeId);

            return new ProductViewModel()
            {
                Id = knife.Id,
                ImageUrl = knife.ImageUrl,
                Name = knife.Name,
                Price = knife.Price
            };
        }
    }
}