using Microsoft.Data.SqlClient;
using VirtualPocket.Model.Market;

namespace VirtualPocket.DAL.Market
{
    public class ChildrenMarketOrderService:IPurchaseSetService
    {
        IConnectionService _connectionService;


        public ChildrenMarketOrderService([FromKeyedServices("ChildrenMarketOrderProvider")] IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }





        public async Task<bool> SetPurchase(ProductSetForm product)
        {
            try
            {
                using (SqlConnection connection = _connectionService.GetConnection())
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand(_connectionService.GetQueryAction(), connection))
                    {

                        command.Parameters.AddWithValue("@title", product.Title);
                        command.Parameters.AddWithValue("@description", product.Description);
                        command.Parameters.AddWithValue("@price", product.Price);
                        command.Parameters.AddWithValue("@category", product.Category);
                        command.Parameters.AddWithValue("@assign", product.Assign);
                        command.Parameters.AddWithValue("@status", product.Status);

                        // Jei tavo id NĖRA automatinis (IDENTITY), atkomentuok šią eilutę:
                        // command.Parameters.AddWithValue("@id", item.Id);

                        // Atliekame async INSERT operaciją
                        int rowsAffected = await command.ExecuteNonQueryAsync();

                        // rowsAffected grąžina įrašytų eilučių skaičių (pvz., 1 jei pavyko)
















                    }




                }






            }
            catch (Exception ex)
            {
                return false;
            }






            return true;
        }
    }
}
