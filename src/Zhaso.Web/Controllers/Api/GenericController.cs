using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zhaso.Interfaces;

namespace Zhaso.Web.Controllers.Api
{
    public abstract class GenericController<T> : Controller where T : EntityBase
    {
        protected IRepository<T> Repository { private set; get; }
        public GenericController(IRepository<T> repository)
        {
            Repository = repository;
        }

        [HttpGet]
        public async virtual Task<IEnumerable<T>> GetAsync(int limit = 20, int page = 1, string order = null)
        {
            if (limit > 0)
            {
                return await Repository.GetPagedListAsync(null, o => o.Id, page, limit);
            }
            return await Repository.GetListAsync();
        }

        [HttpGet("{id}")]
        public async virtual Task<T> GetAsync(int id)
        {
            return await Repository.GetEntityAsync(id);
        }

        [HttpPost]
        public async virtual Task PostAsync([FromBody]T value)
        {
            await Repository.AddAsync(value);
        }

        [HttpPut("{id}")]
        public async virtual Task PutAsync(int id, [FromBody]T value)
        {
            value.Id = id;
            await Repository.UpdateAsync(value);
        }

        [HttpDelete("{id}")]
        public async virtual Task DeleteAsync(int id)
        {
            await Repository.DeleteAsync(id);
        }
    }
}
