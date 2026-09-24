using Microsoft.Data.SqlClient;
using VirtualPocket.Model;
using VirtualPocket.Model.Market;

namespace VirtualPocket.DAL.Market
{
    public class ChildrenMarketGetService : IPurchaseGetService
    {
        IConnectionService _connectionService;

        public ChildrenMarketGetService([FromKeyedServices("ChildrenMarketGetProvider")] IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }



        public async Task<IEnumerable<Product>> GetPrurchases(int uniqueId)
        {
            List<Product> productList = new List<Product>();

            try
            {
                using (SqlConnection connection = _connectionService.GetConnection())
                {



                    await connection.OpenAsync();
                  using (SqlCommand command = new SqlCommand(_connectionService.GetQueryAction(), connection))
                                {
                                    command.Parameters.Add(new SqlParameter("@uniqueId", uniqueId));
					
					                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                                    {
                                        while (await reader.ReadAsync())
                                        {
                                            Product productForm = new Product
                                            {
                                                Title = reader.IsDBNull(reader.GetOrdinal("title")) ? null : reader.GetString(reader.GetOrdinal("title")),
                                                Description = reader.IsDBNull(reader.GetOrdinal("description")) ? null : reader.GetString(reader.GetOrdinal("description")),
                                                Category = reader.IsDBNull(reader.GetOrdinal("category")) ? 0 : reader.GetInt32(reader.GetOrdinal("category")),
                                                Price = reader.IsDBNull(reader.GetOrdinal("price")) ? 0 : reader.GetInt32(reader.GetOrdinal("price")),
                                                Id = reader.IsDBNull(reader.GetOrdinal("id")) ? 0 : reader.GetInt32(reader.GetOrdinal("id")),
                                                Status = reader.IsDBNull(reader.GetOrdinal("status")) ? null: reader.GetString(reader.GetOrdinal("status"))
                               




                                            };



                                            productList.Add(productForm);
                                        }


                                    }


                                }

                }
              

            }
            catch (Exception ex)
            {

                return new List<Product>();
            }



            return productList;
        }
    }
}
