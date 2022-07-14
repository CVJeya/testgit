using System;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace UnitTest
{
   public class TaskClient
   {
        private const string MessageToFrontEnd = "This is the base address Absolute URI of client ";
        private readonly JsonSerializerOptions options = new JsonSerializerOptions()
      {
         PropertyNameCaseInsensitive = true,
         PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      };

      
      private readonly HttpClient client;
      
      private readonly ILogger<TaskClient> _logger;

      public TaskClient(HttpClient client, ILogger<TaskClient> logger)
      {
         this.client = client;
         this._logger = logger;
      }

      public async Task<TaskInfo[]> GetTasksAsync()
      {
#pragma warning disable CA2241 // Provide correct arguments to formatting methods
            Console.WriteLine(MessageToFrontEnd + this.client.BaseAddress.AbsoluteUri);
#pragma warning restore CA2241 // Provide correct arguments to formatting methods
            try
            {
            var responseMessage = await this.client.GetAsync("/Taskinfo");
           
            if (responseMessage!=null)
            {
               var stream = await responseMessage.Content.ReadAsStreamAsync();
               return await JsonSerializer.DeserializeAsync<TaskInfo[]>(stream, options);
            }
         }
         catch(HttpRequestException ex)
         {
            _logger.LogError(ex.Message);
              throw;
         }
         return new TaskInfo[] {};

      }
   }
}