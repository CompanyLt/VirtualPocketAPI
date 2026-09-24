using VirtualPocket.Model;

namespace VirtualPocket.DAL.Tasks
{
    public interface ITaskGetService
    {


        


       Task <IEnumerable<TaskForm>> GetTasks(int uniqueId);



    }
}
