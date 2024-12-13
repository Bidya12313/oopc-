public interface IUserRepository
{
    void AddUser(UserAccount user);
    UserAccount GetUserByName(string userName);
    void UpdateUser(UserAccount user);
    List<UserAccount> GetAllUsers();
}
