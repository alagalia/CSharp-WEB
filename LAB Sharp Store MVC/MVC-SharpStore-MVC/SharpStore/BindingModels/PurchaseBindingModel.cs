using SharpStore.Models;

namespace SharpStore.BindingModels
{
    public class PurchaseBindingModel
    {
        public string BuyerName { get; set; }
        public string BuyerPhoneNumber { get; set; }
        public string BuyerAddress { get; set; }
        public string DeliveryType { get; set; }
    }
}