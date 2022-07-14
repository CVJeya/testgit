using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnitTestApi.Data;

using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using UnitTestApi.Provider.Contracts;

namespace UnitTestApi.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class TaskInfoController : ControllerBase
    {
        private readonly ITaskProvider _TaskProvider ;
       
        private readonly ILogger _Logger ;

        public TaskInfoController( ITaskProvider taskProvider, ILogger<TaskInfoController> logger)
        {
            _TaskProvider = taskProvider;
            _Logger = logger;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<TaskInfo>> GetTasks()
        {
            return _TaskProvider.GetTasks().ToList();
        }

        [HttpGet("{taskId}")]
        public ActionResult<TaskInfo> GetTask(int taskId)
        {
            return _TaskProvider.GetTask(taskId);
        }

        [HttpPost]
        public void AddTask(TaskInfo task)
        {
            _TaskProvider.AddTask(task);
        }
       
        [HttpGet("FetchTaskName")]
        public string FetchTaskName(int taskId)
        {
            string taskName;
            switch (taskId)
            {
                case 1:
                    taskName = "Setting up the Environment for the Project";
                    return taskName;
                   
                case 2:
                    taskName = "Designing Front End";
                    return taskName;
                 
                case 3:
                    taskName = "Designing Database";
                    return taskName;
                  
                case 4:
                    taskName = "Connecting the API with the database";
                    return taskName;
                  
                case 5:
                    taskName = "Execute Docker";
                    return taskName;
                 
                case 6:
                    taskName = "Link the docker images using Docker Compose";
                    return taskName;
                
                default:
                    taskName = "Not Found";
                    return taskName;

            }
      }
    }
}
