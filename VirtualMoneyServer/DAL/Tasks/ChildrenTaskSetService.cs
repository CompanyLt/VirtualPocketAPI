using VirtualPocket.Model;

namespace VirtualPocket.DAL.Tasks
{
    public class ChildrenTaskSetService:ITaskSetService
    {
        IConnectionService _connectionService;

        //public ChildrenTaskSetService([FromKeyedServices("ChildrenTaskSetProvider")]IConnectionService connectionService)
        //{
        //    _connectionService = connectionService;
        //}

        public async Task<bool> SetTask(TaskForm taskForm)
        {




            return true;
        }
    }
}
