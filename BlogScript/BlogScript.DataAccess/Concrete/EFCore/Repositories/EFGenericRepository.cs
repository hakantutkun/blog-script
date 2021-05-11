using BlogScript.DataAccess.Abstract;
using BlogScript.DataAccess.Concrete.EFCore.Context;
using BlogScript.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogScript.DataAccess.Concrete.EFCore.Repositories
{
    public class EFGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, IBlogEntity, new()
    {
        public async Task<List<TEntity>> GetAllAsync()
        {
            using var context = new BlogContext();
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new BlogContext();
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector)
        {
            using var context = new BlogContext();
            return await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            using var context = new BlogContext();
            return await context.Set<TEntity>().OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new BlogContext();
            return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task AddAsync(TEntity entity)
        {
            using var context = new BlogContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            using var context = new BlogContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using var context = new BlogContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
