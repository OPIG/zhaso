using System.Collections.Generic;
using System.Threading.Tasks;
using Zhaso.Entities;
using Zhaso.Interfaces;

namespace Zhaso.Services
{
    public interface IPermissionService : IService<Permission>
    {
        IList<Permission> GetPermissions(int userId, PermissionMode permissionMode = PermissionMode.All);
        Task<IList<Permission>> GetPermissionsAsync(int userId, PermissionMode permissionMode = PermissionMode.All);
    }
}
