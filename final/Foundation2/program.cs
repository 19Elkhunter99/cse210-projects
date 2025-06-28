class Program
{
    static void Main()
    {
        Address addr1 = new Address("123 Maple St", "Rexburg", "ID", "USA");
        Customer cust1 = new Customer("Connor", addr1);
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Keyboard", "KB101", 25.99, 1));
        order1.AddProduct(new Product("Mouse", "M100", 15.49, 2));

        Console.WriteLine("Packing Label:\n" + order1.GetPackingLabel());
        Console.WriteLine("\nShipping Label:\n" + order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order1.GetTotalCost():0.00}");
    }
}
