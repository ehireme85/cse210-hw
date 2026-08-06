// Product.cs
// Stores the name, product ID, price per unit, and quantity of a product.

class Product
{
    private string _name;
    private string _productId;
    private double _pricePerUnit;
    private int    _quantity;

    public Product(string name, string productId, double pricePerUnit, int quantity)
    {
        _name         = name;
        _productId    = productId;
        _pricePerUnit = pricePerUnit;
        _quantity     = quantity;
    }

    public string Name
    {
        get { return _name; }
    }

    public string ProductId
    {
        get { return _productId; }
    }

    // Returns the total cost for this product (price × quantity).
    public double GetTotalCost()
    {
        return _pricePerUnit * _quantity;
    }
}
