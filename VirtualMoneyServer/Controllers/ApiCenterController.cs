using Microsoft.AspNetCore.Mvc;
using VirtualPocket.DAL.ApiCenter;
using VirtualPocket.Model;

namespace VirtualPocket.Controllers
{

    [Route("api/MainApiCenter")]
    [ApiController]
    public class ApiCenterController : ControllerBase
    {

        IGetApiCommandsService _getApiCommandsService;

        public ApiCenterController([FromKeyedServices("GetApiCommandsService")] IGetApiCommandsService getApiCommandsService) 
        {
        
            _getApiCommandsService = getApiCommandsService;
        }

        [HttpPost("Authentication")]
        public async Task<IActionResult> Authentication([FromBody]ApiAuthenticationRequest request)
        {

            try
            {

                return Ok(await _getApiCommandsService.GetApiCommandsAsync(request.apiKey));



            }
            catch (Exception ex)
            {



                return BadRequest(ex.Message);
            }





          
        }
    }
}
