using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace UnitTest.Pages
{
    public class TasksModel : PageModel
    {
        private readonly ILogger<TasksModel> _logger;


        public TaskInfo[] Tasks { get; set; }

        public string ErrorMessage { get; set; }

        public TasksModel(ILogger<TasksModel> logger)
        {
            _logger = logger;

        }

        public async Task OnGet([FromServices] TaskClient client)
        {

            Tasks = await client.GetTasksAsync();

            if (Tasks.Count() == 0)
                ErrorMessage = "Data could not be fetched from the database since SSL connection could not be established";
            else
                ErrorMessage = string.Empty;
        }
    }
}
