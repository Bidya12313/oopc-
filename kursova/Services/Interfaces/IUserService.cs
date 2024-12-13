public interface IUserService
{
    void CreateUser(UserAccount user);
    UserAccount GetUser(string userName);
    void AddBalance(string userName, int amount);
    void MakePurchase(string userName, string productName, int quantity);
}
