using Microsoft.AspNetCore.Mvc;
using Zhaso.Entities;
using Zhaso.Interfaces;

namespace Zhaso.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class CustomersController : GenericController<Customer>
    {
        public CustomersController(IRepository<Customer> repository)
            : base(repository)
        { }
    }
}
