using Zhaso.Entities;
using Zhaso.Interfaces;

namespace Zhaso.Services
{
    public class CategoryService : ServiceBase<Category>, IService<Category>
    {
        public CategoryService(IRepository<Category> respository)
            : base(respository)
        { }
    }
}
