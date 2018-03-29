using System.Collections.Generic;
using System.Threading.Tasks;
using Zhaso.Entities;
using Zhaso.Interfaces;

namespace Zhaso.Repositories
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        IList<Permission> GetPermissions(int userId, PermissionMode permissionMode = PermissionMode.All);
        Task<IList<Permission>> GetPermissionsAsync(int userId, PermissionMode permissionMode = PermissionMode.All);
    }
}
