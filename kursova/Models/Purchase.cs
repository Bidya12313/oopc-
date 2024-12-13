public class Purchase
{
    public string ProductName { get; }
    public int Quantity { get; }
    public int TotalCost { get; }

    public Purchase(string productName, int quantity, int totalCost)
    {
        ProductName = productName;
        Quantity = quantity;
        TotalCost = totalCost;
    }
}