using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MT.serverless
{
    public static class ServerlessDreidel
    {
        // נ (Nun), ג (Gimmel), ה (Hay), ש (Shin)
        private static readonly char[] _dreidelSites = new char[] { 'נ', 'ג', 'ה', 'ש' };

        [FunctionName("ServerlessDreidel")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Dreidel was spinned.");

            Random rand = new Random();
            char result = _dreidelSites[rand.Next(_dreidelSites.Length)];

            log.LogInformation($"Dreidel landed on {result}");

            return (ActionResult)new OkObjectResult(result);
        }
    }
}
