
using System.Collections.Generic;
using UnitTestApi.Data;
using UnitTestApi.Data.Repositories;
using UnitTestApi.Provider.Contracts;

namespace UnitTestApi.Provider
{
    public class TaskProvider : ITaskProvider
    {
        private readonly ITaskRepository taskRepository;

        public TaskProvider(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }
        public void AddTask(TaskInfo task)
        {
            taskRepository.AddTask(task);
        }

        public TaskInfo GetTask(int taskId)
        {
            return taskRepository.GetTask(taskId);
        }

        public IEnumerable<TaskInfo> GetTasks()
        {
            return taskRepository.GetTasks();
        }

       
    }
}
