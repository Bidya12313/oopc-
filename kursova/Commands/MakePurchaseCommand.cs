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
        Console.Write("Введіть ім'я користувача: ");
        string userName = Console.ReadLine();

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
