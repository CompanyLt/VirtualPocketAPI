using Microsoft.AspNetCore.Mvc;
using VirtualPocket.DAL.Authentication;
using VirtualPocket.Model;

namespace VirtualPocket.Controllers
{
    [ApiController]
    [Route("api/parentAuthentication")]
    public class ParentAuthenticationController : Controller
    {
       
        IRegistrationService _registrationService;
        ILoginService _authenticationService;
        private readonly ILogger<ParentAuthenticationController> _logger;

        public ParentAuthenticationController([FromKeyedServices("ParentRegistrationService")] IRegistrationService registrationService, ILogger<ParentAuthenticationController> logger, [FromKeyedServices("ParentAuthenticationService")] ILoginService authenticationService) 
        { 
        _registrationService = registrationService;
            _authenticationService = authenticationService;
            _logger = logger;
        }





        [HttpPost("registration",Name ="ParentRegistration")]
        public async Task<IActionResult> RegistrationParent([FromBody] RegistrationModel registrationModel)
        {
           




            try
            {
             if(await _registrationService.SetUser(registrationModel))
                        {
                    return CreatedAtAction(nameof(RegistrationParent), new { mail = registrationModel.Email }, new User {Name=registrationModel.Name, UniqueId = registrationModel.uniqueId});
                }
                else
                {
                    return BadRequest(new ErrorResponse{ErrorCode="1000",Message="Toks akauntas yra"});
                }

            }catch(Exception ex)
            {
                _logger.LogError(ex, "Registracijos klaida");
                var errorResponse = new ErrorResponse
                {
                    Message = "Vidinė serverio klaida",
                    Detail = ex.Message, 
                    ErrorCode = HttpContext.TraceIdentifier 
                };
                return StatusCode(500, errorResponse);

            }

         
           

          
        }

        [HttpPost("authentication",Name = "ParentAuthentication")]
        public async Task<IActionResult> AuthenticateParent([FromBody]LoginModel loginModel)
        {
               

            try
            {
               if(await _authenticationService.GetUser(loginModel))
                {
                    return Ok(new User {Name=loginModel.Username,UniqueId=loginModel.uniqueId});

                }
                else
                {
                    return BadRequest(new ErrorResponse { ErrorCode = "1001", Message = "Neteisingas slaptazodis arba vartotojo vardas" });
                }




            }catch(Exception ex)
            {
                _logger.LogError(ex, "Registracijos klaida");
                return StatusCode(500, "Vidine serverio problema");


            }

           
        }



    }
}
