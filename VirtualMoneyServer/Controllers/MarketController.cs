using Microsoft.AspNetCore.Mvc;

using VirtualPocket.Model.Market;
namespace VirtualPocket.Controllers
{
    [ApiController]
    [Route("api/market")]
    public class MarketController : Controller
    {
       


        public MarketController()
        {
        
        }


        [HttpGet("GetProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts ()
            {
            return Ok();
            }


        [HttpGet("SetProducts")]
        public async Task<IActionResult> SetProducts()
        {
            return Ok();
        }



    }
}
