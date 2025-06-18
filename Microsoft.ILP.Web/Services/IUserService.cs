namespace Microsoft.ILP.Web.Services
{
    public interface IUserService
    {
        Task<string> GetUsersAsync();
    }
}
