
using Microsoft.Data.SqlClient;
using VirtualPocket.Model;

namespace VirtualPocket.DAL.PocketPlace
{
    public class CollectRewardService : ICollectRewardService
    {
        IConnectionService _collectionRewardService;

        public CollectRewardService([FromKeyedServices("CollectRewardProvider")]IConnectionService collectionRewardService) 
        { 
        _collectionRewardService = collectionRewardService;
        }
        public async Task<bool> Execute(RewardForm rewardForm)
        {
            try
            {


                using (SqlConnection connection = _collectionRewardService.GetConnection())
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = _collectionRewardService.GetQueryAction();
                        command.Parameters.Add(new SqlParameter("@id",rewardForm.UniqueId));
                        command.Parameters.Add(new SqlParameter("@reward", rewardForm.Reward));


                      await  command.ExecuteNonQueryAsync();
                    }




                }




                return true;

            }
            catch (Exception ex)
            {
               return false;
            }





        }
    }
}
