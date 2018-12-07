using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Alexa.NET.Response;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace AlexaSkill
{

    public static class AlexaSkill
    {
        [FunctionName("AlexaSkill")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            /*
             * Alexa will send command via JSON payload, included in the body, therefore first step read content of the body
             */
            string json = await req.ReadAsStringAsync();

            //deserialize json
            var skillRequest = JsonConvert.DeserializeObject<SkillRequest>(json);

            SkillResponse response = null;

            var requestType = skillRequest.GetRequestType();

            if (requestType == typeof(LaunchRequest)){

                //here we could call the API and return the ans as a SkillResponse Object. 
                response = ResponseBuilder.Tell("Welcome to the Art of Possible");
                
                //alexa won't close the session, waiting for other commands to send to the same skill. 
                response.Response.ShouldEndSession = false;
            }

            else if (requestType == typeof(IntentRequest))
            {
                //the name of the slot, replace with you own value
                
                //TO DO: Pass this as an env variable
                var SLOT = "any";
                var intentRequest = skillRequest.Request as IntentRequest;
                
                //get the message that the user sent to Alexa 
                var alexaInput = intentRequest.Intent.Slots[SLOT].Value;

                var myjson = "{'question':'" +  alexaInput + "'}";
                
                //create a request to Azure Bot Framework 
                HttpClient httpClient = new HttpClient();
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, Utilities.GetEnvironmentVariable("Url"));
                requestMessage.Headers.Add(Utilities.GetEnvironmentVariable("HeaderName"), Utilities.GetEnvironmentVariable("HeaderValue"));
                requestMessage.Content = new StringContent(myjson, Encoding.UTF8, "application/json");

                // Send the request to the server             
                var res = httpClient.SendAsync(requestMessage)
                    .Result
                    .Content
                    .ReadAsStringAsync()
                    .Result;

                //Parse the result 
                dynamic tmp = JsonConvert.DeserializeObject(res);
                string value = tmp.answers[0].answer;

                response = ResponseBuilder.Tell(value);
                response.Response.ShouldEndSession = false;
            }
            return new OkObjectResult(response);
        }
    }
}
