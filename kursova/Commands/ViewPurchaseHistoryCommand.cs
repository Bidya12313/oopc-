public class ViewPurchaseHistoryCommand : ICommand
{
    private readonly IPurchaseService _purchaseService;
    private readonly UserAccount _user;

    public ViewPurchaseHistoryCommand(IPurchaseService purchaseService, UserAccount user)
    {
        _purchaseService = purchaseService;
        _user = user;
    }

    public void Execute()
    {
        if (Program.loggedInUser == null)
        {
            Console.WriteLine("Будь ласка, увійдіть у систему для перегляду історії покупок.");
            return;
        }

        var purchases = _purchaseService.GetPurchaseHistory(Program.loggedInUser);

        if (purchases.Count == 0)
        {
            Console.WriteLine("У вас ще немає покупок.");
        }
        else
        {
            Console.WriteLine("Історія покупок:");
            foreach (var purchase in purchases)
            {
                Console.WriteLine($"Товар: {purchase.ProductName}, Кількість: {purchase.Quantity}, Загальна вартість: {purchase.TotalCost}");
            }
        }
    }

    public void DisplayOptions()
    {
        Console.WriteLine("Перегляд історії покупок.");
    }
}
