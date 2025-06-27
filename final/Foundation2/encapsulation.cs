using System;
using System.Collections.Generic;

// ---------------- ADDRESS CLASS ----------------
class Address
{
    private string street;
    private string city;
    private string stateProvince;
    private string country;

    public Address(string street, string city, string stateProvince, string country)
    {
        this.street = street;
        this.city = city;
        this.stateProvince = stateProvince;
        this.country = country;
    }

    public bool IsUSA()
    {
        return country.Trim().ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {stateProvince}\n{country}";
    }
}

// ---------------- CUSTOMER CLASS ----------------
class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string GetName() => name;

    public Address GetAddress() => address;

    public bool LivesInUSA() => address.IsUSA();
}

// ---------------- PRODUCT CLASS ----------------
class Product
{
    private string name;
    private string productId;
    private double pricePerUnit;
    private int quantity;

    public Product(string name, string productId, double pricePerUnit, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.pricePerUnit = pricePerUnit;
        this.quantity = quantity;
    }

    public double GetTotalPrice() => pricePerUnit * quantity;

    public string GetPackingInfo() => $"{name} (ID: {productId})";
}

// ---------------- ORDER CLASS ----------------
class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalCost()
    {
        double productTotal = 0;
        foreach (Product p in products)
            productTotal += p.GetTotalPrice();

        double shippingCost = customer.LivesInUSA() ? 5 : 35;
        return productTotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product p in products)
            label += "- " + p.GetPackingInfo() + "\n";
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
    }
}

// ---------------- MAIN PROGRAM ----------------
class Program
{
    static void Main()
    {
        // Address and Customer Setup
        Customer customer1 = new Customer("Alice Johnson", new Address("123 Maple St", "Springfield", "IL", "USA"));
        Customer customer2 = new Customer("Liam Chen", new Address("88 Sakura Rd", "Tokyo", "Kanto", "Japan"));

        // First Order
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Notebook", "A101", 4.99, 3));
        order1.AddProduct(new Product("Pen Set", "B202", 2.50, 2));
        
        // Second Order
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Gaming Mouse", "G505", 45.00, 1));
        order2.AddProduct(new Product("Mechanical Keyboard", "K606", 80.00, 1));
        order2.AddProduct(new Product("USB-C Cable", "U707", 9.99, 2));

        // Display Results
        List<Order> orders = new List<Order> { order1, order2 };

        int orderNumber = 1;
        foreach (Order o in orders)
        {
            Console.WriteLine($"--- Order {orderNumber} ---");
            Console.WriteLine(o.GetPackingLabel());
            Console.WriteLine(o.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${o.GetTotalCost():0.00}");
            Console.WriteLine(new string('-', 40));
            orderNumber++;
        }
    }
}
