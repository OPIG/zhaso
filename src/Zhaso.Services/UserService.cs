using System;
using System.Threading.Tasks;
using Zhaso.Entities;
using Zhaso.Interfaces;

namespace Zhaso.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        public UserService(IRepository<User> respository)
            : base(respository)
        { }

        public async Task<User> Login(string loginName, string password)
        {
            var user = await Repository.GetEntityAsync(o => o.LoginName == loginName);
            if (user == null)
            {
                throw new Exception("不存在这个用户！");
            }
            if (user.Password != password.GetMd5X16())
            {
                throw new Exception("密码不正确！");
            }

            return user;
        }
    }
}
