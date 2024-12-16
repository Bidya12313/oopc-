public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;

    public UserService(IUserRepository userRepository, IProductRepository productRepository)
    {
        _userRepository = userRepository;
        _productRepository = productRepository;
    }

    public UserAccount Authenticate(string username, string password)
    {
        return _userRepository.GetUserByUsernameAndPassword(username, password);
    }

    public void CreateUser(UserAccount user)
    {
        _userRepository.AddUser(user);
    }

    public UserAccount GetUser(string userName)
    {
        return _userRepository.GetUserByName(userName);
    }

    public void AddBalance(string userName, int amount)
    {
        var user = _userRepository.GetUserByName(userName);
        if (user == null)
            throw new Exception("Користувач не знайдений.");

        user.AddBalance(amount);
        _userRepository.UpdateUser(user);
    }

    public void MakePurchase(string userName, string productName, int quantity)
    {
        var user = _userRepository.GetUserByName(userName);
        if (user == null)
            throw new Exception("Користувач не знайдений.");

        var product = _productRepository.GetProductByName(productName);
        if (product == null)
            throw new Exception("Товар не знайдено.");

        user.MakePurchase(product, quantity, userName);

        _userRepository.UpdateUser(user);
        _productRepository.UpdateProduct(product);
    }
}
