using Microsoft.Extensions.Options;
using Microsoft.ILP.Web.Settings;
using System.Runtime;

namespace Microsoft.ILP.Web.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient client;

        private readonly UserServiceEndpoints userServiceEndpoints;

        public UserService(HttpClient client, UserServiceEndpoints userServiceEndpoints)
        {
            this.client = client;
            this.userServiceEndpoints = userServiceEndpoints;
            this.client.BaseAddress = new Uri(this.userServiceEndpoints.BaseAddress);
            this.client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<string> GetUsersAsync()
        {
            var response = await this.client.GetAsync(this.userServiceEndpoints.GetUsers);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return await Task.FromResult(string.Empty);
            }
        }
    }
}