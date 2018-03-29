using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Zhaso.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(int id);
        Task DeleteAsync(int id);
        T GetEntity(int id);
        T GetEntity(Expression<Func<T, bool>> selector = null);
        Task<T> GetEntityAsync(int id);
        Task<T> GetEntityAsync(Expression<Func<T, bool>> selector = null);
        List<T> GetList(Expression<Func<T, bool>> selector = null);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> selector = null);
        List<T> SqlQuery(string sql, params object[] parameters);
        Task<List<T>> SqlQueryAsync(string sql, params object[] parameters);
        IPagedList<T> GetPagedList<TKey>(Expression<Func<T, bool>> selector, Expression<Func<T, TKey>> orderBy = null, int page = 1, int pageSize = 20);
        Task<IPagedList<T>> GetPagedListAsync<TKey>(Expression<Func<T, bool>> selector, Expression<Func<T, TKey>> orderBy = null, int page = 1, int pageSize = 20);
    }
}
