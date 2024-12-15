using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace MasterDataSync
{
    public static class SyncMaterialCategory
    {
        [FunctionName("SyncMaterialCategory")]
        public static void Run([TimerTrigger("*/30 */1 * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
