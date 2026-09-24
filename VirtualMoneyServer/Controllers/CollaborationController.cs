using Microsoft.AspNetCore.Mvc;
using VirtualPocket.DAL.Collaboration;
using VirtualPocket.Model;
using VirtualPocket.Model.Collaborate;

namespace VirtualPocket.Controllers
{
    [ApiController]
    [Route("api/Collaboration")]
    public class CollaborationController : Controller
    {
        private readonly  ICollaborateSetService _collaborateSetService;
        private readonly ICollaborateRemoveService _collaborateRemoveService;
        private readonly ICollaborateGetService _collaborateGetService;


        public CollaborationController([FromKeyedServices("CollaborateSetService")]ICollaborateSetService collaborateSetService, [FromKeyedServices("CollaborateRemoveService")] ICollaborateRemoveService collaborateRemoveService, [FromKeyedServices("CollaborateGetService")]ICollaborateGetService collaborateGetService) {
        
        _collaborateSetService = collaborateSetService;
            _collaborateRemoveService = collaborateRemoveService;
            _collaborateGetService = collaborateGetService;
        }



        [HttpPost("AddChildToParent")]
        public async Task<IActionResult> AddChildToParent([FromBody]ParentChildrenRequest parentChildrenRequest)
        {
            try
            {

                return Ok(await _collaborateSetService.SetCollaborate(parentChildrenRequest.parentId, parentChildrenRequest.childrenId));

            }catch (Exception ex)
            {
            return BadRequest(new ErrorResponse { ErrorCode = "1001", Message = "Tokio vaiko nera" });
            }





          
        }

        [HttpGet("GetChildren")]
        public async Task<IActionResult> GetChildrenCollaborate(int parentId)
        {
            try
            {

                return Ok(await _collaborateGetService.GetCollaborate(parentId));



            }catch (Exception ex)
            {



                return BadRequest(ex.Message);
            }
            
           


               

 

        }

        [HttpPost("RemoveChildFromParent")]
        public async Task<IActionResult> RemoveChildFromParent(int parentId, int childrenId)
        {


            if (await _collaborateRemoveService.RemoveCollaborate(parentId, childrenId))
            {


                return Ok();

            }
            else
            {
                return BadRequest(new ErrorResponse { ErrorCode = "1001", Message = "istrynti nepavyko" });
            }
        }
    }
}
