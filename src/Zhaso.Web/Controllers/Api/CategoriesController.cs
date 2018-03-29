using Microsoft.AspNetCore.Mvc;
using Zhaso.Entities;
using Zhaso.Interfaces;

namespace Zhaso.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class CategoriesController : GenericController<Category>
    {
        public CategoriesController(IRepository<Category> repository)
           : base(repository)
        { }
    }
}
