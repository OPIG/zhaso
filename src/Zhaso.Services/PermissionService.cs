using System.Collections.Generic;
using System.Threading.Tasks;
using Zhaso.Entities;
using Zhaso.Repositories;

namespace Zhaso.Services
{
    public class PermissionService : ServiceBase<Permission>, IPermissionService
    {
        public PermissionService(IPermissionRepository respository) : base(respository)
        {
        }

        public IList<Permission> GetPermissions(int userId, PermissionMode permissionMode = PermissionMode.All)
        {
            return (Repository as IPermissionRepository).GetPermissions(userId, permissionMode);
        }

        public Task<IList<Permission>> GetPermissionsAsync(int userId, PermissionMode permissionMode = PermissionMode.All)
        {
            return (Repository as IPermissionRepository).GetPermissionsAsync(userId, permissionMode);
        }
    }
}
