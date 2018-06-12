using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.Testing
{
    class Program
    {
        static void Main(string[] args)
        {

            RunPostOperation();
        }

        private static Uri _serviceUri = new Uri("http://localhost:34130/AccountGroup");

        private static void RunPostOperation()
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, _serviceUri);
            requestMessage.Headers.ExpectContinue = false;

            AccountGroup account = new AccountGroup()
            {
                GroupName = "Assets",
                Description = "Assets group of account",
                AddedDate = DateTime.MinValue,
                ModifiedDate = DateTime.MinValue
            };

            string jsonInputs = JsonConvert.SerializeObject(account);
            requestMessage.Content = new StringContent(jsonInputs, Encoding.UTF8, "application/json");
            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 10, 0);
            Task<HttpResponseMessage> httpRequest = httpClient.SendAsync(requestMessage,
                    HttpCompletionOption.ResponseContentRead, CancellationToken.None);
            HttpResponseMessage httpResponse = httpRequest.Result;
            HttpStatusCode statusCode = httpResponse.StatusCode;
            HttpContent responseContent = httpResponse.Content;
            if (responseContent != null)
            {
                Task<String> stringContentsTask = responseContent.ReadAsStringAsync();
                String stringContents = stringContentsTask.Result;
                Console.WriteLine("Response from service: " + stringContents);
            }
            Console.ReadKey();
        }
    }
}
