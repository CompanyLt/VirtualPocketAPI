using Microsoft.AspNetCore.Mvc;
using VirtualPocket.DAL.Market;

using VirtualPocket.Model.Market;
namespace VirtualPocket.Controllers
{
    [ApiController]
    [Route("api/Market")]
    public class MarketController : Controller
    {

        IPurchaseGetService _purchaseGetService;
        IPurchaseSetService _purchaseSetService;


        public MarketController([FromKeyedServices("ChildrenMarketGetService")]IPurchaseGetService purchaseGetService,
            [FromKeyedServices("ChildrenMarketSetService")] IPurchaseSetService purchaseSetService)
        {
            _purchaseGetService = purchaseGetService;
            _purchaseSetService = purchaseSetService;
        
        }

     

        [HttpGet("GetProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts (int uniqueId)
            {

            try
            {

                return Ok(await _purchaseGetService.GetPrurchases(uniqueId));



            }
            catch (Exception ex)
            {



                return BadRequest(ex.Message);
            }




        }


        [HttpPost("SetProducts")]
        public async Task<IActionResult> SetProducts([FromBody]ProductSetForm productForm)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // 2. Iškviečiame įrašymo servisą
                // (Pastaba: pakeisk '_marketSetService' į savo serviso kintamojo pavadinimą)
                bool isSuccess = await _purchaseSetService.SetPurchase(productForm);

                if (isSuccess)
                {
                    return Ok(new { message = "Produktas sėkmingai pridėtas!" });
                }

                return BadRequest(new { message = "Nepavyko įrašyti produkto į duomenų bazę." });
            }
            catch (Exception ex)
            {
                // 3. Klaidų tvarkymas
                return StatusCode(500, new { message = "Serverio klaida išsaugant produktą", error = ex.Message });
            }






           
        }

        [HttpPost("Orders")]
        public async Task<IActionResult> BuyProduct([FromBody] ProductSetForm productForm)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // 2. Iškviečiame įrašymo servisą
                // (Pastaba: pakeisk '_marketSetService' į savo serviso kintamojo pavadinimą)
                bool isSuccess = await _purchaseSetService.SetPurchase(productForm);

                if (isSuccess)
                {
                    return Ok(new { message = "Produktas sėkmingai pridėtas!" });
                }

                return BadRequest(new { message = "Nepavyko įrašyti produkto į duomenų bazę." });
            }
            catch (Exception ex)
            {
                // 3. Klaidų tvarkymas
                return StatusCode(500, new { message = "Serverio klaida išsaugant produktą", error = ex.Message });
            }







        }



    }
}
