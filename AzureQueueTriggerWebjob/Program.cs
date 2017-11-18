using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Configuration;

namespace AzureQueueTriggerWebjob
{
    class Program
    {
        static void Main(string[] args)
        {
            var _storageConn = ConfigurationManager
           .ConnectionStrings["AzureWebJobsStorage"].ConnectionString;

            var _dashboardConn = ConfigurationManager
           .ConnectionStrings["AzureWebJobsDashboard"].ConnectionString;

            JobHostConfiguration config = new JobHostConfiguration();
            config.StorageConnectionString = _storageConn;
            //config.DashboardConnectionString = _dashboardConn;
            config.UseTimers();
            config.Queues.MaxDequeueCount = 2;
            config.Queues.MaxPollingInterval = TimeSpan.FromSeconds(4);
            config.Queues.BatchSize = 2;

            JobHost host = new JobHost(config);
            host.RunAndBlock();
        }

    }
}
