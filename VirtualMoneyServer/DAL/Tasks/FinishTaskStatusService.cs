using VirtualPocket.Model;

namespace VirtualPocket.DAL.Tasks
{
    public class FinishTaskStatusService:ITaskStatusService
    {






        public FinishTaskStatusService() { }

        public async Task<bool> Execute(TaskForm taskForm)
        {
            return true;


        }
    }
}
