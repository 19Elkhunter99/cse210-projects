public class Product
{
    private string _name;
    private int _price;
    private int _quantity;

    public Product(string name, int price, int quantity)
    {
        _name = name;
        _price = price;
        _quantity = quantity;
    }

    public int GetTotalPrice() => _price * _quantity;

    public string GetDetails() => $"{_name} - ${_price} x {_quantity} = ${GetTotalPrice()}";
}

public class Customer
{
    public string Name { get; set; }
    public string Address { get; set; }

    public Customer(string name, string address)
    {
        Name = name;
        Address = address;
    }
}

public class Order
{
    private Customer _customer;
    private List<Product> _products = new List<Product>();

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public void DisplayOrder()
    {
        Console.WriteLine($"Customer: {_customer.Name}");
        Console.WriteLine($"Shipping to: {_customer.Address}");
        int total = 0;
        foreach (var product in _products)
        {
            Console.WriteLine(product.GetDetails());
            total += product.GetTotalPrice();
        }
        Console.WriteLine($"Total: ${total}");
    }
}
