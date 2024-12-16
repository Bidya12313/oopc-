public class PurchaseRepository : IPurchaseRepository
{
    private readonly DbContext _dbContext;

    public PurchaseRepository(DbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public List<Purchase> GetPurchasesHistory(UserAccount user)
    {
        return _dbContext.Purchases.Where(p => p.UserName == user.UserName).ToList();
    }
}
