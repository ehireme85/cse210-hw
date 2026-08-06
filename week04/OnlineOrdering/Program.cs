// Program.cs
// Demonstrates the Order, Product, Customer, and Address classes.
// Creates two orders and displays packing labels, shipping labels, and total prices.

using System;

class Program
{
    static void Main(string[] args)
    {
        // ── ORDER 1: US customer ─────────────────────────────────────────────
        Address usAddress = new Address(
            "742 Evergreen Terrace",
            "Springfield",
            "IL",
            "USA"
        );
        Customer usCustomer = new Customer("Homer Simpson", usAddress);

        Order order1 = new Order(usCustomer);
        order1.AddProduct(new Product("Wireless Mouse",     "WM-4821", 29.99, 2));
        order1.AddProduct(new Product("USB-C Hub",          "UC-1134", 49.99, 1));
        order1.AddProduct(new Product("Mechanical Keyboard","MK-7755", 89.99, 1));

        // ── ORDER 2: International customer ──────────────────────────────────
        Address intlAddress = new Address(
            "10 Downing Street",
            "London",
            "England",
            "UK"
        );
        Customer intlCustomer = new Customer("James Harrison", intlAddress);

        Order order2 = new Order(intlCustomer);
        order2.AddProduct(new Product("Noise-Cancelling Headphones", "NC-9901", 199.99, 1));
        order2.AddProduct(new Product("Laptop Stand",                "LS-3302",  34.99, 2));

        // ── Display both orders ───────────────────────────────────────────────
        DisplayOrder(order1);
        Console.WriteLine();
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine("========================================");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"  Total Price: ${order.GetTotalPrice():F2}");
        Console.WriteLine("========================================");
    }
}
