public class Purchase
{
    public string ProductName { get; }
    public int Quantity { get; }
    public int TotalCost { get; }
    public string UserName { get; }

    public Purchase(string productName, int quantity, int totalCost, string userName)
    {
        ProductName = productName;
        Quantity = quantity;
        TotalCost = totalCost;
        UserName = userName;
    }
}
