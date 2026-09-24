using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VirtualPocket.DAL.Authentication;
using VirtualPocket.DAL.Tasks;
using VirtualPocket.Model;

namespace VirtualPocket.Controllers
{
    [ApiController]
    [Route("api/TaskCenter")]
    public class TaskController : Controller
    {
       
        ITaskGetService _taskGetService;
        ITaskSetService _taskSetService;
        ITaskStatusService _taskStartService;
        ITaskCategoryService _taskCategoryGetService;
        ILogger<TaskController> _logger;


        public TaskController([FromKeyedServices("ChildrenTaskGetService")]ITaskGetService childrenTaskGetService,
            [FromKeyedServices("ChildrenTaskSetService")]ITaskSetService childrenTaskSetService,
            [FromKeyedServices("StartTaskStatusService")]ITaskStatusService taskStatusService,
            [FromKeyedServices("TaskCategoryGetService")]ITaskCategoryService taskCategoryGetService,
            ILogger<TaskController> logger) 
        {
            _taskGetService = childrenTaskGetService;
            _taskSetService = childrenTaskSetService;
            _taskStartService = taskStatusService;
            _taskCategoryGetService = taskCategoryGetService;
            _logger = logger;
        }

        //[HttpGet("GetDailyTask")]
        //public async Task<IActionResult> GetDailyTask()
        //{
           

        //    return Ok();
        //}
        //[HttpGet("GetWeeklyTask")]
        //public async Task<IActionResult> GetWeeklyTask()
        //{


        //    return Ok();
        //}
        //[HttpGet("GetMonthlyTask")]
        //public async Task<IActionResult> GetMonthlyTask(string uniqueId)
        //{


        //    return Ok();
        //}
        [HttpPost("SetTask")]
        public async Task<IActionResult> SetTask([FromBody]TaskForm taskForm)
        {


            try
            {
                if (await _taskSetService.SetTask(taskForm))
                {
                    return CreatedAtAction(nameof(SetTask), new { id = taskForm.UniqueId,name=taskForm.Category }, taskForm);
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


        [HttpGet("GetTasks")]
        public async Task<IActionResult> GetTasks(int uniqueId)
        {


            try
            {

                return Ok(await _taskGetService.GetTasks(uniqueId));



            }
            catch (Exception ex)
            {



                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetTaskCategory")]
        public async Task<IActionResult> GetTaskCategory()
        {
            try
            {
                return Ok( await _taskCategoryGetService.GetTaskCategories());
            }
            catch
            {
                return BadRequest(new ErrorResponse { ErrorCode = "1002", Message = "Nesekmingas TaskImage grazinimas" });
            }
        }


        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTask([FromBody]TaskForm taskForm)
        {
            try
            {
            if(await _taskStartService.Execute(taskForm))
                        {

                    return Ok();
                        }


            }catch
            {
                return BadRequest(new ErrorResponse { ErrorCode = "1001", Message = "Nesekmingas atnaujinimas" });
            }
            


            return Ok();
        }


    }
}
