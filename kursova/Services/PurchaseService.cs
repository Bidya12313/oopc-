public class PurchaseService : IPurchaseService
{
    public List<Purchase> GetPurchaseHistory(UserAccount user)
    {
        return user.PurchaseHistory;
    }
}
