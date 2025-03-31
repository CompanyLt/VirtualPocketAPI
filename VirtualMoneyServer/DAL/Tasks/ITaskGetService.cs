using VirtualPocket.Model;

namespace VirtualPocket.DAL.Tasks
{
    public interface ITaskGetService
    {


        


       Task <IEnumerable<TaskForm>> GetTask(string uniqueId);



    }
}
