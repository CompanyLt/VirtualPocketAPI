using VirtualPocket.Model.Market;

namespace VirtualPocket.DAL.Market
{
    public interface IPurchaseSetService
    {




        Task<bool> SetPurchase(Product product);
    }
}
