using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace UnitTestApi.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DataContext>>()))
            {
                if (context == null || context.TaskInfo == null)
                {
                    throw new ArgumentNullException("Null Task Info Context");
                }

                // Look for any movies.
                if (context.TaskInfo.Any())
                {
                    return;   // DB has been seeded
                }

                context.TaskInfo.AddRange(

                   new TaskInfo {  TaskName = "Setting up the Environment for the Project", Description = "Complete setting up of the environment for the project", HoursNeeded = 30, Status = "IsActive" },
                   new TaskInfo { TaskName = "Designing Front End", Description = "Designing the screens needed for the project", HoursNeeded = 30, Status = "IsActive" },
                   new TaskInfo { TaskName = "Designing Database", Description = "Designing the database needed for the project", HoursNeeded = 30, Status = "IsActive" },
                   new TaskInfo { TaskName = "Connecting the API with the database", Description = "Connect using api endpoints with the database and perform CRUD operations", HoursNeeded = 30, Status = "IsActive" },
                   new TaskInfo { TaskName = "Execute Docker", Description = "Run each module as a docker image", HoursNeeded = 20, Status = "IsActive" },
                   new TaskInfo {  TaskName = "Link the docker images using Docker Compose", Description = "Link all the modules using the docker images and run under a single container using Docker-Compose.YAML", HoursNeeded = 20, Status = "IsActive" }

                );
                context.SaveChanges();
            }
        }
    }
}
