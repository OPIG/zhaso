using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zhaso.Entities;
using Zhaso.Repositories;

namespace Zhaso.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class UsersController : GenericController<User>
    {
        public UsersController(IUserRepository userRepository)
            : base(userRepository)
        { }

        [HttpGet("{id}/roles")]
        public async Task<IEnumerable<Role>> GetRolesAsync(int id)
        {
            await Task.Delay(0);
            return new List<Role>() { new Role { Id = 1, RoleName = "Test" } };
        }

        [HttpGet("{id}/permissions")]
        public async Task<IEnumerable<Permission>> GetPermissionsAsync(int id)
        {
            await Task.Delay(0);
            return new List<Permission>() { new Permission { Id = 1, ActionName = "Test" } };
        }
    }
}
