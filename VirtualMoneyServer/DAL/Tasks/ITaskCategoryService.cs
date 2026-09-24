using VirtualPocket.Model;

namespace VirtualPocket.DAL.Tasks
{
    public interface ITaskCategoryService
    {


        Task<IEnumerable<TaskCategoryForm>> GetTaskCategories();
        
    }
}
