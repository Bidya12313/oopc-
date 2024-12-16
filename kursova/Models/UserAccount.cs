using System;
using System.Collections.Generic;
public class UserAccount
{
    public string UserName { get; }
    public string Password { get; }
    public int Balance { get; private set; }
    public List<Purchase> PurchaseHistory { get; }

    public UserAccount(string userName, int balance, string password)
    {
        if (balance < 0)
            throw new ArgumentException("Баланс не може бути від'ємним.");

        UserName = userName;
        Password = password ?? throw new ArgumentException("");
        Balance = balance;
        PurchaseHistory = new List<Purchase>();
    }

    public void AddBalance(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сума поповнення має бути більше нуля.");

        Balance += amount;
    }

    public void MakePurchase(Product product, int quantity, string username)
    {
        int totalCost = product.Price * quantity;
        if (totalCost > Balance)
            throw new Exception("Недостатньо коштів для покупки.");

        if (product.Quantity < quantity)
            throw new Exception("Недостатньо товару на складі.");

        Balance -= totalCost;
        product.Quantity -= quantity;
        Purchase purchase = new Purchase(product.Name, quantity, totalCost, username);
        PurchaseHistory.Add(purchase);
    }
}