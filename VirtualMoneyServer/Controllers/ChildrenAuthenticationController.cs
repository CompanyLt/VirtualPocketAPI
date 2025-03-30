using Microsoft.AspNetCore.Mvc;
using VirtualPocket.DAL.Authentication;
using VirtualPocket.Model;

namespace VirtualPocket.Controllers
{
    [ApiController]
    [Route("api/childrenAuthentication")]
    public class ChildrenAuthenticationController : Controller
    {
        private readonly IRegistrationService _registrationService;
        private readonly ILogger<ChildrenAuthenticationController> _logger;

        public ChildrenAuthenticationController([FromKeyedServices("ChildrenRegistrationService")] IRegistrationService registrationService,ILogger<ChildrenAuthenticationController> logger) 
        { 
            _registrationService = registrationService;
            _logger = logger;
        }



        [HttpPost("registration",Name = "ChildrenRegistration")]
        public async Task<IActionResult> RegistrationChildren([FromBody]RegistrationModel registrationModel)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                if(await _registrationService.SetUser(registrationModel))
                {
                    return CreatedAtAction(nameof(RegistrationChildren), new { name = registrationModel.Name },"Registracija sekminga");
                }
                else
                {
                    return BadRequest(new ErrorResponse { ErrorCode="1000",Message="toks akauntas yra"});
                }

            }catch(Exception ex)
            {
                _logger.LogError(ex, "Vidine klaida");
                return BadRequest(StatusCode(500, "Vidine klaida"));
            }




            
        }

        [HttpPost("authentication",Name = "ChildrenAuthentication")]
        public async Task<IActionResult> AuthenticateChildren(string userName, string password)
        {


            return Ok("grazinimas");
        }
    }
}
