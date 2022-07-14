using System;
using System.Collections.Generic;
using UnitTestApi.Data;

namespace UnitTestApi.Provider.Contracts
{
    public interface ITaskProvider
    {
        IEnumerable<TaskInfo> GetTasks();
        TaskInfo GetTask(int taskId);
        void AddTask(TaskInfo task);
       
    }
}
