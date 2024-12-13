public class AddProductCommand : ICommand
{
    private readonly IProductService _productService;

    public AddProductCommand(IProductService productService)
    {
        _productService = productService;
    }

    public void Execute()
    {
        Console.Write("Введіть ім'я користувача: ");
        string userName = Console.ReadLine();

        Console.Write("Введіть назву продукту: ");
        string name = Console.ReadLine();

        Console.Write("Введіть ціну: ");
        int price = int.Parse(Console.ReadLine());

        Console.Write("Введіть кількість: ");
        int quantity = int.Parse(Console.ReadLine());

        Product newProduct = new Product(name, price, quantity);

        _productService.AddProduct(newProduct);

        Console.WriteLine($"Користувач {userName} додав {quantity} шт. товару {name}.");
    }

    public void DisplayOptions()
    {
        Console.WriteLine("Додати новий продукт.");
    }
}
