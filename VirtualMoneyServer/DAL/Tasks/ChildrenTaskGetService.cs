using VirtualPocket.Model;

namespace VirtualPocket.DAL.Tasks
{
    public class ChildrenTaskGetService:ITaskGetService
    {

   IConnectionService _connectionService;


        //public ChildrenTaskGetService([FromKeyedServices("ChildrenTaskGetProvider")]IConnectionService connectionService)
        //{
        //    _connectionService = connectionService;
        //}

        

        public async Task<IEnumerable<TaskForm>> GetTask(string uniqueId)
        {
            return new List<TaskForm>();
        }


    }
}
