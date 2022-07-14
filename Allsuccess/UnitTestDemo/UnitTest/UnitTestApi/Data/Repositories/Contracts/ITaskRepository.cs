using System.Collections.Generic;
using UnitTestApi.Data;

namespace UnitTestApi.Data.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<TaskInfo> GetTasks();
        TaskInfo GetTask(int taskId);
        void AddTask(TaskInfo task);
        bool Save();
     
    }
}
