using System.Collections.Generic;

public class DbContext
{
    public List<UserAccount> Users { get; set; }
    public List<Product> Products { get; set; }
    public List<Purchase> Purchases { get; set; }

    public DbContext()
    {
        Users = new List<UserAccount>
        {
            new UserAccount("User1", 100, "password1"),
            new UserAccount("User2", 200, "password2"),
            new UserAccount("User3", 300, "password3")
        };

        Products = new List<Product>
        {
            new Product("Product1", 50, 10),
            new Product("Product2", 30, 20),
            new Product("Product3", 20, 15)
        };

        Purchases = new List<Purchase>();
    } 
}
