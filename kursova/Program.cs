public class Program
{
    static void Main()
    {
        DbContext dbContext = new DbContext();
        IUserRepository userRepo = new UserRepository(dbContext);
        IProductRepository productRepo = new ProductRepository(dbContext);
        IUserService userService = new UserService(userRepo, productRepo);
        IProductService productService = new ProductService(productRepo);

        ICommand displayProducts = new DisplayProductsCommand(productService);
        ICommand registerUser = new RegisterUserCommand(userService);
        ICommand addBalance = new AddBalanceCommand(userService);
        ICommand makePurchase = new MakePurchaseCommand(userService, productService);
        ICommand addProduct = new AddProductCommand(productService);

        Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>
        {
            { "1", displayProducts },
            { "2", registerUser },
            { "3", addBalance },
            { "4", makePurchase },
            { "5", addProduct }
        };

         Menu menu = new Menu(commands);

        while (true)
        {
            menu.DisplayMenu();

            string option = Console.ReadLine();

            if (option == "6") break;

            menu.ExecuteCommand(option);
        }
    }
}
