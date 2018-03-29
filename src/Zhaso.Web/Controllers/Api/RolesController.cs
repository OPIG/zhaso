using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Zhaso.Entities;
using Zhaso.Interfaces;

namespace Zhaso.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class RolesController : GenericController<Role>
    {
        public RolesController(IRepository<Role> repository)
             : base(repository)
        { }

        [HttpGet("{id}/users")]
        public async Task<IEnumerable<User>> GetUsers(int id)
        {
            await Task.Delay(0);
            return null;
        }
    }
}
