namespace Microsoft.ILP.Web.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient client;        

        public UserService(HttpClient client)
        {
            this.client = client;
            this.client.BaseAddress = new Uri("https://localhost:7279/");
            this.client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<string> GetUsersAsync()
        {
            var response = await this.client.GetAsync("user");

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