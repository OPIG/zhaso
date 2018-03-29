using System.Threading.Tasks;
using Zhaso.Entities;
using Zhaso.Interfaces;

namespace Zhaso.Services
{
    public interface IUserService : IService<User>
    {
        Task<User> Login(string loginName, string password);
    }
}
