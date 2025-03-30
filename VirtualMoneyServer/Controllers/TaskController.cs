using Microsoft.AspNetCore.Mvc;
using VirtualPocket.DAL.Tasks;
using VirtualPocket.Model;

namespace VirtualPocket.Controllers
{
    [ApiController]
    [Route("api/TaskCenter")]
    public class TaskController : Controller
    {
       
        ITaskService _taskService;
        ILogger<TaskController> _logger;


        public TaskController(ITaskService taskService, ILogger<TaskController> logger) 
        {
            _taskService = taskService;
            _logger = logger;
        }

        [HttpGet("GetDailyTask")]
        public async Task<IActionResult> GetDailyTask()
        {


            return Ok();
        }
        [HttpGet("GetWeeklyTask")]
        public async Task<IActionResult> GetWeeklyTask()
        {


            return Ok();
        }
        [HttpGet("GetMonthlyTask")]
        public async Task<IActionResult> GetMonthlyTask(string uniqueId)
        {


            return Ok();
        }
        [HttpGet("SetTask")]
        public async Task<IActionResult> SetTask([FromBody]TaskForm taskForm)
        {






            return Ok();
        }
        //Uzduociu pridejimas



    }
}
