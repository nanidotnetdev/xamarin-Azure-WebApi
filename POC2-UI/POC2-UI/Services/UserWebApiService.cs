using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace POC2_UI.Services
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using POC2_UI.Models;

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

                    response.EnsureSuccessStatusCode();

                    var jsonString = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<User>(jsonString);
                }
            }
        }

        /// <summary>
        /// Get all Users.
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<User>> GetAllUsers()
        {
            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, ServiceConstants.Urls.GetAllUserEntities))
                {
                    request.Headers.Add("Ocp-Apim-Subscription-Key", ServiceConstants.SubscriptionKeys.PrimaryKey);
                    HttpResponseMessage response = null;

                    using (var cancellationToken = new CancellationTokenSource())
                    {
                        cancellationToken.CancelAfter(TimeSpan.FromSeconds(ServiceConstants.Defaults.ServiceTimeoutInSecs));

                        response = await client.SendAsync(request, cancellationToken.Token).ConfigureAwait(false);
                    }

                    response.EnsureSuccessStatusCode();

                    var json = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<ICollection<User>>(json);
                }
            }
        }

        /// <summary>
        /// Save User Entity.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> SaveUser(User user)
        {
            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, ServiceConstants.Urls.SAveUserEntity))
                {
                    HttpResponseMessage response = null;

                    request.Headers.Add("Ocp-Apim-Subscription-Key", ServiceConstants.SubscriptionKeys.PrimaryKey);

                    //Instead of POST Async add content in the request.
                    request.Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");;

                    using (var cancellationToken = new CancellationTokenSource())
                    {
                        cancellationToken.CancelAfter(TimeSpan.FromSeconds(ServiceConstants.Defaults.ServiceTimeoutInSecs));

                        response = await client.SendAsync(request, cancellationToken.Token)
                            .ConfigureAwait(false);

                    }

                    response.EnsureSuccessStatusCode();

                    var jsonString = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<User>(jsonString);
                }
            }
        }

        /// <summary>
        /// Delete User Entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> DeleteUser(Guid id)
        {
            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, string.Format(ServiceConstants.Urls.DeleteUserEntity, id)))
                {
                    HttpResponseMessage response = null;

                    request.Headers.Add("Ocp-Apim-Subscription-Key", ServiceConstants.SubscriptionKeys.PrimaryKey);

                    using (var cancellationToken = new CancellationTokenSource())
                    {
                        cancellationToken.CancelAfter(TimeSpan.FromSeconds(ServiceConstants.Defaults.ServiceTimeoutInSecs));

                        response = await client.SendAsync(request, cancellationToken.Token)
                            .ConfigureAwait(false);
                    }

                    response.EnsureSuccessStatusCode();

                    return response.StatusCode;
                }
            }
        }
    }
}
