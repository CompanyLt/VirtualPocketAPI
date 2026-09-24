using Microsoft.AspNetCore.Mvc;
using VirtualPocket.DAL.PocketPlace;
using VirtualPocket.Model;

namespace VirtualPocket.Controllers
{
    [ApiController]
    [Route("api/Pocket")]
    public class PocketController : ControllerBase
    {

        ICollectRewardService _rewardService;
        IGetPocketService _getPocketService;
        public PocketController([FromKeyedServices("CollectRewardService")]ICollectRewardService collectRewardService, [FromKeyedServices("GetPocketService")]IGetPocketService getPocketService) 
        {
        _rewardService = collectRewardService;
            _getPocketService = getPocketService;
        }

        [HttpPut("CollectReward")]
        public async Task<IActionResult> CollectReward([FromBody]RewardForm rewardForm)
        {


            try
            {
                if(await _rewardService.Execute(rewardForm))
                {

                 return Ok();

                }
                else
                {
                    return BadRequest(new ErrorResponse { Detail="Error",ErrorCode="1000",Message="Nepavyko"});
                }

              



            }
            catch (Exception ex)
            {



                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetPocket")]
        public async Task<IActionResult> GetPocket(int uniqueId)
        {


            try
            {
              

                    return Ok(await _getPocketService.getPocketAsync(uniqueId));

                              

            }
            catch (Exception ex)
            {



                return BadRequest(new ErrorResponse { Detail = "Error", ErrorCode = "1000", Message = "Nepavyko" });
            }
        }









    }
}
