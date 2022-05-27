namespace Share.Models
{
    public class Product
    {
        public String Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public Product(string name, int quantity, int price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }
    }
}
