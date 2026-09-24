

using VirtualPocket.Model;

namespace VirtualPocket.DAL.PocketPlace
{
    public interface ICollectRewardService
    {



        Task<bool> Execute(RewardForm rewardForm);


    }
}
