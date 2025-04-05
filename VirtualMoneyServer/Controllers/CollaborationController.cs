using Microsoft.AspNetCore.Mvc;

namespace VirtualPocket.Controllers
{
    [ApiController]
    [Route("api/collaboration")]
    public class CollaborationController : Controller
    {
        [HttpPost("AddChildToParent")]
        public async Task<IActionResult> AddChildToParent(string parentId, string childrenId)
        {


            return Ok();
        }

        [HttpPost("RemoveChildFromParent")]
        public async Task<IActionResult> RemoveChildFromParent(string parentId, string childrenId)
        {


            return Ok();
        }
    }
}
