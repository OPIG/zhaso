using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Zhaso.Entities
{
    public class SeedData
    {
        public static void Initialize(DbContext context)
        {
            context.Database.Migrate();
            var users = context.Set<User>();
            var roles = context.Set<Role>();
            if (!users.Any())
            {
                var admin = users.Add(new User
                {
                    Name = Constants.Administrator,
                    LoginName = Constants.Admin,
                    Password = Constants.AdminPassword.GetMd5X16()
                });
                var adminRole = roles.Add(new Role
                {
                    RoleName = Constants.Administrator,
                    SimpleName = Constants.Admin,
                    CreateUser = Constants.System,
                    UpdateUser = Constants.System,
                });
                roles.Add(new Role
                {
                    RoleName = Constants.All,
                    SimpleName = Constants.All,
                    CreateUser = Constants.System,
                    UpdateUser = Constants.System,
                });
                context.Set<RoleUser>().Add(new RoleUser
                {
                    Role = adminRole.Entity,
                    User = admin.Entity,
                    CreateUser = Constants.System,
                    UpdateUser = Constants.System,
                });
            }
            
            context.SaveChanges();
        }
    }
}
