public class MakePurchaseCommand : ICommand
{
    private readonly IUserService _userService;
    private readonly IProductService _productService;

    public MakePurchaseCommand(IUserService userService, IProductService productService)
    {
        _userService = userService;
        _productService = productService;
    }

    public void Execute()
    {
         if (Program.loggedInUser == null)
        {
            Console.WriteLine("Будь ласка, увійдіть в систему для покупки.");
            return;
        }

        string userName = Program.loggedInUser.UserName;

        Console.Write("Введіть назву товару: ");
        string productName = Console.ReadLine();

        Console.Write("Введіть кількість: ");
        int quantity = int.Parse(Console.ReadLine());

        _userService.MakePurchase(userName, productName, quantity);
        Console.WriteLine($"Користувач {userName} придбав {quantity} шт. товару {productName}.");
    }

    public void DisplayOptions()
    {
        Console.WriteLine("Купити товар.");
    }
}
