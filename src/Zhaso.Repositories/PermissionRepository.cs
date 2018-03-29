using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Zhaso.Entities;

namespace Zhaso.Repositories
{
    public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(DbContext dbContext)
            : base(dbContext)
        { }

        public IList<Permission> GetPermissions(int userId, PermissionMode permissionMode = PermissionMode.All)
        {
            var tuple = GetPermissionsSql(userId, permissionMode);
            return SqlQuery(tuple.CommandText, tuple.Parameters);
        }

        public async Task<IList<Permission>> GetPermissionsAsync(int userId, PermissionMode permissionMode = PermissionMode.All)
        {
            var tuple = GetPermissionsSql(userId, permissionMode);
            return await SqlQueryAsync(tuple.CommandText, tuple.Parameters);
        }

        private (string CommandText, List<SqlParameter> Parameters) GetPermissionsSql(int userId, PermissionMode permissionMode = PermissionMode.All)
        {
            string where = "";
            List<SqlParameter> paramlist = new List<SqlParameter>()
            {
                new SqlParameter("@userId", userId)
            };
            if (permissionMode != PermissionMode.All)
            {
                where = " and M.Mode=@Mode";
                paramlist.Add(new SqlParameter("@Mode", permissionMode));
            }
            string sql = $@"select M.* 
                            from Permissions M
                                inner join RolePermissions RM on RM.PermissionId = M.Id
                                left join RoleUsers UR on UR.RoleId = RM.RoleId
                                inner join Roles R on RM.RoleId = R.Id
                            where (UR.UserId = @userId or R.RoleName='{Constants.All}') {where}
                            order by M.[Order]";

            return (sql, paramlist);
        }
    }
}
