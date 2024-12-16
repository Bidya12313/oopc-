public interface IPurchaseRepository
{
    List<Purchase> GetPurchasesHistory(UserAccount user);
}
