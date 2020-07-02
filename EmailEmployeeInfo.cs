using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using SendGrid.Helpers.Mail;

namespace TkuOisAzFunc120096
{
    public static class EmailEmployeeInfo
    {
        [FunctionName("EmailEmployeeInfo")]
        public static void Run(
            [QueueTrigger("employees", Connection = "AzureWebJobsStorage")]string input,
            [Table ("employees", "employees", "{queueTrigger}")] Employee employee,
            [SendGrid(ApiKey = "SendGridApiKey")] out SendGridMessage message,
            ILogger log)
        {
            message = new SendGridMessage();
        }
    }
}
