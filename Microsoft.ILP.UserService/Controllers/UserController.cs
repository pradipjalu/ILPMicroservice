using Microsoft.AspNetCore.Mvc;
using Microsoft.ILP.Entities;

namespace Microsoft.ILP.UserService.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {        
        private readonly ILogger<UserController> logger;

        public UserController(ILogger<UserController> logger)
        {
            this.logger = logger;
        }

        [HttpGet(Name = "GetAll")]
        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            var users = new List<UserEntity>() { 
                new UserEntity(){ Id=1, Name ="Pradip"},
                new UserEntity(){ Id=1, Name ="Jalu"},
            };

            return await Task.FromResult(users);
        }
    }
}
