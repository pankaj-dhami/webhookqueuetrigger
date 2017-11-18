using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage.Queue;
using System;

namespace AzureQueueTriggerWebjob
{
    public class BackgroundJobs
    {
        public static void TriggerFunction([QueueTrigger("pdqueue")]CloudQueueMessage message)
        {
            var queuemessge = message.AsString;
            System.Console.WriteLine(queuemessge);
        }
        public static void FiveSecondTask([TimerTrigger("* */1  */0 * * *")] TimerInfo timer)
        {
            Console.WriteLine("This should run every 5 seconds");
        }

        //  ┌───────────── minute(0 - 59)
        //# │ ┌───────────── hour (0 - 23)
        //# │ │ ┌───────────── day of month (1 - 31)
        //# │ │ │ ┌───────────── month (1 - 12)
        //# │ │ │ │ ┌───────────── day of week (0 - 6) (Sunday to Saturday;
        //# │ │ │ │ │                                       7 is also Sunday on some systems)
        //# │ │ │ │ │
        //# │ │ │ │ │
        //# * * * * *  command to execute
    }
}
