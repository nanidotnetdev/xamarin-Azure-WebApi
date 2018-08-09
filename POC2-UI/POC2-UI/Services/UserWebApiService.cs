using POC2_UI.Models;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace POC2_UI.Services
{
    public class UserWebApiService
    {
        public async Task<User> GetUserAsync(Guid userId)
        {
            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, string.Format(ServiceConstants.Urls.GetUserEntity, userId)))
                {
                    request.Headers.Add("Ocp-Apim-Subscription-Key", ServiceConstants.SubscriptionKeys.PrimaryKey);

                    HttpResponseMessage response = null;

                    using (var cancellationSource = new CancellationTokenSource())
                    {
                        cancellationSource.CancelAfter(TimeSpan.FromSeconds(ServiceConstants.Defaults.ServiceTimeoutInSecs));

                        response = await client.SendAsync(request, cancellationSource.Token).ConfigureAwait(false);
                    }

                    var jsonString = await response.Content.ReadAsStringAsync();

                    var res = JsonConvert.DeserializeObject<User>(jsonString);

                    return res;
                }
            }
        }

       
    }
}
