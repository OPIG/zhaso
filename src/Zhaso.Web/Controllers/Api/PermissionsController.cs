using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zhaso.Entities;
using Zhaso.Interfaces;

namespace Zhaso.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class PermissionsController : GenericController<Permission>
    {
        public PermissionsController(IRepository<Permission> repository)
             : base(repository)
        { }

        [HttpGet("{id}/roles")]
        public async Task<IEnumerable<Role>> GetrRolesAsync(int id)
        {
            await Task.Delay(0);
            return null;
        }
    }
}
