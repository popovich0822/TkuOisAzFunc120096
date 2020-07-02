using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TkuOisAzFunc120096
{
    public static class GetEmployeeData
    {
        [FunctionName("GetEmployeeData")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [Queue("employees")] IAsyncCollector<string> rowKeyQueue,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<Employee>(requestBody);

            await rowKeyQueue.AddAsync(data.RowKey);

            return new OkObjectResult($"We've got your employee id, we'll send your information later.");
        }
    }
}