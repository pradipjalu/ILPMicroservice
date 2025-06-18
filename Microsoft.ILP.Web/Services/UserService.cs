namespace Microsoft.ILP.Web.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient client;

        public UserService(HttpClient client)
        {
            this.client = client;
            this.client.BaseAddress = new Uri("https://api.example.com/");
        }

        public async Task<string> GetUsersAsync()
        {
            var response = await this.client.GetAsync("endpoint");

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