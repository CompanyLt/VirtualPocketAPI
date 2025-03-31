using VirtualPocket.Model;

namespace VirtualPocket.DAL.Tasks
{
    public interface ITaskSetService
    {


        Task<bool> SetTask(TaskForm taskForm);
    }
}
