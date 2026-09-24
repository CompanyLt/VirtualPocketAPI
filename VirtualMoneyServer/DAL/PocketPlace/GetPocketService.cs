
using Microsoft.Data.SqlClient;
using VirtualPocket.Model;

namespace VirtualPocket.DAL.PocketPlace
{
    public class GetPocketService : IGetPocketService
    {
        IConnectionService _getPocketProvider;

        public GetPocketService([FromKeyedServices("GetPocketProvider")]IConnectionService getPocketProvider) 
        {
            _getPocketProvider = getPocketProvider;
        }






        public async  Task<Pocket> getPocketAsync(int uniqueId)
        {

            try
            {


                using (SqlConnection connection = _getPocketProvider.GetConnection())
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = connection.CreateCommand())
                    {

                        command.CommandText = _getPocketProvider.GetQueryAction();
                        command.Parameters.Add(new SqlParameter("@id", uniqueId));
                       using(SqlDataReader reader = await command.ExecuteReaderAsync()) 
                        {
                            if(await reader.ReadAsync())
                            {
                                return new Pocket
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    balance = reader.GetInt32(reader.GetOrdinal("balance"))
                                };



                               
                            
                            }




                        }


                      
                    }




                }



                return new Pocket();


            }
            catch (Exception ex)
            {
               return new Pocket();
            }



           
        }
    }
}
