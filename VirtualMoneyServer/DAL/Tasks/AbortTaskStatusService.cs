using VirtualPocket.Model;

namespace VirtualPocket.DAL.Tasks
{
    public class AbortTaskStatusService:ITaskStatusService
    {
        public AbortTaskStatusService() { }



        public async Task<bool> Execute(TaskForm taskForm)
        {




            return true;
        }
    }
}
