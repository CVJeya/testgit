using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestApi.Data.Repositories;

namespace UnitTestApi.Data.Repositories
{
    public class TaskRepository : ITaskRepository, IDisposable
    {
        private readonly DataContext _context;

        public TaskRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<TaskInfo> GetTasks()
        {
            return _context.TaskInfo;
        }

        public TaskInfo GetTask(int taskId)
        {
            return _context.TaskInfo.SingleOrDefault(a => a.Id == taskId);
        }



        public void AddTask(TaskInfo task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            _context.TaskInfo.Add(task);
            Save();
        }


        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
      

    }
}
