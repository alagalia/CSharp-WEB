namespace AddCake
{
    public class Cake
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Cake(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{this.Name};{this.Price}";
        }
    }
}