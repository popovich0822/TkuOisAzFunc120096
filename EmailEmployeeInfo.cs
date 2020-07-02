using System.Net.Http;
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
            [Table("employees", "employees", "{queueTrigger}")]Employee employee,
            [SendGrid(ApiKey = "SendGridApiKey")] out SendGridMessage message,
            ILogger log)
        {
            var email = employee.EmpEmail;

            message = new SendGridMessage();
            message.From = new EmailAddress(Environment.GetEnvironmentVariable("EmailSender"));
            message.Subject = input + "'s personal informaion.";
            message.HtmlContent = "Employee ID: " + employee.RowKey + ", Employee Name: " + employee.EmpName;
            message.AddTo(email);
        }
    }
}
