namespace SharpStore.Models
{
    public class Purchase
    {
        public int  Id { get; set; }
        public string BuyerName { get; set; }
        public string BuyerPhoneNumber { get; set; }
        public string BuyerAddress { get; set; }
        public Delivery DeliveryType { get; set; }
    }

    public enum Delivery
    {
        Express,
        Economic    
    }
}