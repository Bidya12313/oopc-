public class DisplayProductsCommand : ICommand
{
    private readonly IProductService _productService;

    public DisplayProductsCommand(IProductService productService)
    {
        _productService = productService;
    }

    public void Execute()
    {
        var products = _productService.GetAllProducts();
        foreach (var product in products)
        {
            Console.WriteLine($"Назва: {product.Name}, Ціна: {product.Price}, Кількість: {product.Quantity}");
        }
    }

    public void DisplayOptions()
    {
        Console.WriteLine("Відобразити товари.");
    }
}