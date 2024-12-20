public class UserRepository : IUserRepository
{
    private readonly DbContext _context;

    public UserRepository(DbContext context)
    {
        _context = context;
    }

    public UserAccount GetUserByUsernameAndPassword(string username, string password)
    {
    return _context.Users
        .FirstOrDefault(u => u.UserName == username && u.Password == password);
    }


    public void AddUser(UserAccount user)
    {
        _context.Users.Add(user);
    }

    public UserAccount GetUserByName(string userName)
    {
        return _context.Users.Find(u => u.UserName == userName);
    }

    public void UpdateUser(UserAccount user)
    {
        var existingUser = GetUserByName(user.UserName);
        if (existingUser != null)
        {
            existingUser = user;
        }
    }
    public List<UserAccount> GetAllUsers()
    {
        return _context.Users.ToList();
    }
}
