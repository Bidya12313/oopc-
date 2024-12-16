public class Program
{
    public static UserAccount loggedInUser = null;
    static void Main()
    {
        DbContext dbContext = new DbContext();
        IUserRepository userRepo = new UserRepository(dbContext);
        IProductRepository productRepo = new ProductRepository(dbContext);
        IUserService userService = new UserService(userRepo, productRepo);
        IProductService productService = new ProductService(productRepo);
        IPurchaseService purchaseService = new PurchaseService();

        ICommand displayProducts = new DisplayProductsCommand(productService);
        ICommand registerUser = new RegisterUserCommand(userService);
        ICommand addBalance = new AddBalanceCommand(userService);
        ICommand makePurchase = new MakePurchaseCommand(userService, productService);
        ICommand addProduct = new AddProductCommand(productService);
        ICommand loginUser = new LoginCommand(userService);
        ICommand viewUsPurchaseHistory = new ViewPurchaseHistoryCommand(purchaseService, loggedInUser);


        Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>
        {
            { "1", displayProducts },
            { "2", registerUser },
            { "3", loginUser },
            { "4", addBalance },
            { "5", makePurchase },
            { "6", viewUsPurchaseHistory },
            { "7", addProduct },
        };

        Menu menu = new Menu(commands);

        while (true)
        {
            menu.DisplayMenu();

            string option = Console.ReadLine();

            if (option == "8") break;

            menu.ExecuteCommand(option);
        }
    }
}
