using Microsoft.AspNetCore.Mvc;
using VirtualPocket.DAL.Authentication;
using VirtualPocket.Model;

namespace VirtualPocket.Controllers
{
    [ApiController]
    [Route("api/Registration")]
    public class RegistrationController : ControllerBase
    {
        IRegistrationService _parentRegistrationService;
        IRegistrationService _childrenRegistrationService;
        ILogger<RegistrationController> _logger;
        public RegistrationController(ILogger<RegistrationController> logger,[FromKeyedServices("ParentRegistrationService")] IRegistrationService parentRegistrationService, [FromKeyedServices("ChildrenRegistrationService")] IRegistrationService childrenRegistrationService) 
        {
            _parentRegistrationService = parentRegistrationService;
            _childrenRegistrationService = childrenRegistrationService;
            _logger = logger;
        }


        [HttpPost("registration",Name ="Registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationModel registrationModel)
        {

            if (registrationModel.isParent)
            {
 
                return await RegistrationParent(registrationModel);
               
            }
            else
            {
               
                return await RegistrationChildren(registrationModel);
            }



           
        }





        private async Task<IActionResult> RegistrationParent(RegistrationModel registrationModel)
        {


            if (!ModelState.IsValid)
            {

                return BadRequest(new ErrorResponse { ErrorCode = "1000", Message = "Neivesti laukai" });
            }


            try
            {
                if (await _parentRegistrationService.SetUser(registrationModel))
                {
                    //Graziname User
                    return Created("Tevas", new User { Name = registrationModel.Name,Username=registrationModel.Username, UniqueId = registrationModel.uniqueId });
                }
                else
                {
                    return BadRequest(new ErrorResponse { ErrorCode = "1000", Message = "Toks akauntas yra" });
                }

            }
            catch (Exception ex)
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

       
        private async Task<IActionResult> RegistrationChildren(RegistrationModel registrationModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                if (await _childrenRegistrationService.SetUser(registrationModel))
                {
                    return Created("Vaikas", new User { Name = registrationModel.Name,Username=registrationModel.Username, UniqueId = registrationModel.uniqueId });
                }
                else
                {
                    return BadRequest(new ErrorResponse { ErrorCode = "1000", Message = "toks akauntas yra" });
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Vidine klaida");
                return BadRequest(StatusCode(500, "Vidine klaida"));
            }





        }
    }
}
