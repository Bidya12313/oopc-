using System;

public class Product
{
    public string Name { get; }
    public int Price { get; }
    public int Quantity { get; set; }

    public Product(string name, int price, int quantity)
    {
        if (price < 0 || quantity < 0)
            throw new ArgumentException("Ціна або кількість не можуть бути від'ємними.");

        Name = name;
        Price = price;
        Quantity = quantity;
    }
}