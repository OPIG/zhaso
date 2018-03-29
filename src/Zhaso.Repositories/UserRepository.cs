using Microsoft.EntityFrameworkCore;
using Zhaso.Entities;

namespace Zhaso.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext)
            : base(dbContext)
        { }

    }
}
