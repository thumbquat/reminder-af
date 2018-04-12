using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace Remember.Your.Id
{
    public static class Reminder
    {
        [FunctionName("Reminder")]
        public static void Run([TimerTrigger("0 * * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
            const string message = "Remember your id...";
            var number = int.Parse(System.Environment.GetEnvironmentVariable("PhoneNumber"));
            log.Info(number.ToString());
            Sms.Send(number, message);
        }
    }
}
