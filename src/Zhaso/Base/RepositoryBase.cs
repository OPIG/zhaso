using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Zhaso.Base;
using Zhaso.Interfaces;

namespace Zhaso
{
    public class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        protected DbContext Context { set; get; }
        public RepositoryBase(DbContext dbContext)
        {
            Context = dbContext;
        }

        public void Delete(int id)
        {
            var set = Context.Set<T>();
            var entity = set.FirstOrDefault(o => o.Id == id);
            if (entity != null)
            {
                Context.Set<T>().Remove(entity);
                Context.SaveChanges();
            }
        }

        public T GetEntity(int id)
        {
            var set = Context.Set<T>();
            var entity = set.FirstOrDefault(o => o.Id == id);
            return entity;
        }

        public T GetEntity(Expression<Func<T, bool>> selector = null)
        {
            var set = Context.Set<T>();
            if (selector != null)
            {
                return set.FirstOrDefault(selector);
            }
            else
            {
                return set.FirstOrDefault();
            }
        }

        public void Add(T entity)
        {
            var set = Context.Set<T>();
            set.Add(entity);
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            var set = Context.Set<T>();
            var original = set.FirstOrDefault(o => o.Id == entity.Id);
            if (original != null)
            {
                Context.Entry(original).CurrentValues.SetValues(entity);
                Context.SaveChanges();
            }
        }

        public async Task AddAsync(T entity)
        {
            var set = Context.Set<T>();
            set.Add(entity);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var set = Context.Set<T>();
            var original = await set.FirstOrDefaultAsync(o => o.Id == entity.Id);
            if (original != null)
            {
                Context.Entry(original).CurrentValues.SetValues(entity);
                await Context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var set = Context.Set<T>();
            var entity = await set.FirstOrDefaultAsync(o => o.Id == id);
            if (entity != null)
            {
                Context.Set<T>().Remove(entity);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<T> GetEntityAsync(int id)
        {
            var set = Context.Set<T>();
            var entity = await set.FirstOrDefaultAsync(o => o.Id == id);
            return entity;
        }

        public async Task<T> GetEntityAsync(Expression<Func<T, bool>> selector = null)
        {
            var set = Context.Set<T>();
            if (selector != null)
            {
                return await set.FirstOrDefaultAsync(selector);
            }
            else
            {
                return await set.FirstOrDefaultAsync();
            }
        }

        public List<T> GetList(Expression<Func<T, bool>> selector = null)
        {
            var set = Context.Set<T>();
            IQueryable<T> query = set;
            if (selector != null)
            {
                query = set.Where(selector);
            }
            return query.ToList();
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> selector = null)
        {
            var set = Context.Set<T>();
            IQueryable<T> query = set;
            if (selector != null)
            {
                query = set.Where(selector);
            }
            return await query.ToListAsync();
        }

        public List<T> SqlQuery(string sql, params object[] parameters)
        {
            return Context
                .Set<T>()
                .FromSql(sql, parameters)
                .ToList();
        }

        public async Task<List<T>> SqlQueryAsync(string sql, params object[] parameters)
        {
            return await Context
                .Set<T>()
                .FromSql(sql, parameters)
                .ToListAsync();
        }

        public IPagedList<T> GetPagedList<TKey>(Expression<Func<T, bool>> selector, Expression<Func<T, TKey>> orderBy = null, int page = 1, int pageSize = 20)
        {
            var set = Context.Set<T>();
            IQueryable<T> query = set;
            if (selector != null)
            {
                query = set.Where(selector);
            }
            query.OrderBy(orderBy);
            return new PagedList<T>(query, page - 1, pageSize);
        }

        public async Task<IPagedList<T>> GetPagedListAsync<TKey>(Expression<Func<T, bool>> selector, Expression<Func<T, TKey>> orderBy = null, int page = 1, int pageSize = 20)
        {
            var set = Context.Set<T>();
            IQueryable<T> query = set;
            if (selector != null)
            {
                query = set.Where(selector);
            }
            if (orderBy != null)
            {
                query.OrderBy(orderBy);
            }
            var count = query.Count();
            var list = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<T>(list, page - 1, pageSize, count);
        }
    }
}
