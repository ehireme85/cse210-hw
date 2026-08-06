// Order.cs
// Contains a list of products and a customer.
// Can compute the total price, and produce packing and shipping labels.

using System.Collections.Generic;
using System.Text;

class Order
{
    private List<Product> _products;
    private Customer      _customer;

    private const double US_SHIPPING      = 5.00;
    private const double INTL_SHIPPING    = 35.00;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Sums the cost of all products and adds the appropriate shipping fee.
    public double GetTotalPrice()
    {
        double total = 0;
        foreach (Product p in _products)
            total += p.GetTotalCost();

        total += _customer.LivesInUSA() ? US_SHIPPING : INTL_SHIPPING;
        return total;
    }

    // Returns a packing label listing each product's name and ID.
    public string GetPackingLabel()
    {
        var sb = new StringBuilder();
        sb.AppendLine("--- PACKING LABEL ---");
        foreach (Product p in _products)
            sb.AppendLine($"  {p.Name}  (ID: {p.ProductId})");
        return sb.ToString().TrimEnd();
    }

    // Returns a shipping label with the customer's name and full address.
    public string GetShippingLabel()
    {
        var sb = new StringBuilder();
        sb.AppendLine("--- SHIPPING LABEL ---");
        sb.AppendLine(_customer.Name);
        sb.Append(_customer.Address.GetFullAddress());
        return sb.ToString();
    }
}
