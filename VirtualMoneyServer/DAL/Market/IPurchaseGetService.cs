using VirtualPocket.Model.Market;

namespace VirtualPocket.DAL.Market
{
    public interface IPurchaseGetService
    {

        Task<IEnumerable<Product>> GetPrurchases(int uniqueId);


    }
}
