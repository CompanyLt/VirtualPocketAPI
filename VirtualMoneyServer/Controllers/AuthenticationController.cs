using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPocket.DAL.Authentication;
using VirtualPocket.Model;

namespace VirtualPocket.Controllers
{
    [Route("api/Authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

       
        ILoginService _parentLoginService;
        ILoginService _childrenLoginService;

        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController( ILogger<AuthenticationController> logger, [FromKeyedServices("ParentAuthenticationService")] ILoginService parentAuthenticationService, [FromKeyedServices("ChildrenAuthenticationService")] ILoginService childrenAuthenticationService)
        {
            _childrenLoginService = childrenAuthenticationService;
            _parentLoginService = parentAuthenticationService;
            _logger = logger;
        }
       

        [HttpPost("authentication", Name = "Authentication")]
        public async Task<IActionResult> Authentication([FromBody] LoginModel loginModel)
        {
            var parentResult = await AuthenticateParent(loginModel);
           
              if(parentResult is OkObjectResult)
            {
                return parentResult;
            }


              var childrenResult = await AuthenticateChildren(loginModel);
            if(childrenResult is OkObjectResult)
            {
                return childrenResult;
            }

            return BadRequest(new ErrorResponse { ErrorCode = "1001", Message = "Neteisingas slaptazodis arba vartotojo vardas" });
                
            
        }


        [HttpPost("ApiGates")]
        public async Task<IActionResult> Authentication(int uniqueId)
        {


            try
            {

                return Ok();



            }
            catch (Exception ex)
            {



                return BadRequest(ex.Message);
            }
        }







        private async Task<IActionResult> AuthenticateParent([FromBody] LoginModel loginModel)
        {


            try
            {
                if (await _parentLoginService.GetUser(loginModel))
                {

                    return Ok(new User { Name = loginModel.Name, Username = loginModel.Username, UniqueId = loginModel.uniqueId, isParent = true });

                }
                else
                {
                    return BadRequest(new ErrorResponse { ErrorCode = "1001", Message = "Neteisingas slaptazodis arba vartotojo vardas" });
                }




            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Registracijos klaida");
                return StatusCode(500, "Vidine serverio problema");


            }


        }

       
        private async Task<IActionResult> AuthenticateChildren([FromBody] LoginModel loginModel)
        {

            try
            {
                if (await _childrenLoginService.GetUser(loginModel))
                {

                    return Ok(new User { Name = loginModel.Name,Username= loginModel.Username, UniqueId = loginModel.uniqueId,isParent = false, Avatar=loginModel.avatar });

                }
                else
                {
                    return BadRequest(new ErrorResponse { ErrorCode = "1001", Message = "Neteisingas slaptazodis arba vartotojo vardas" });
                }




            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Registracijos klaida");
                return StatusCode(500, "Vidine serverio problema");


            }


           
        }








    }
}
