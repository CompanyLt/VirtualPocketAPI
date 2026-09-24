using VirtualPocket.Model;

namespace VirtualPocket.DAL.Tasks
{
    public interface ITaskStatusService
    {



        Task<bool> Execute(TaskForm taskForm);
        
    }
}
