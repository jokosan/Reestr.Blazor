using Microsoft.EntityFrameworkCore;
using Reestr.Database.Context;
using Reestr.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Infrastructure.Repositories
{
    public class DbRepository<T> : IGetRepository<T>, ICrudRepository<T> where T : class
    {
        private readonly DbContextReestr _dbContextReestr;
        private readonly DbSet<T> _dbSet;

        public DbRepository(DbContextReestr dbContextReestr)
        {
            _dbContextReestr = dbContextReestr;
            _dbSet = dbContextReestr.Set<T>();
        }

        #region CRUD
        public virtual void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (_dbContextReestr.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }

            _dbSet.Remove(entityToDelete);
        }

        public virtual void Update(T entityToUpdate)
        {
            var dbEntityEntry = _dbContextReestr.Entry(entityToUpdate);
            dbEntityEntry.CurrentValues.SetValues(entityToUpdate);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _dbContextReestr.Attach(entityToUpdate);
            }

            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Update(T entityToUpdate, T getEntity)
        {
            var dbEntityEntry = _dbContextReestr.Entry(getEntity);            
            dbEntityEntry.CurrentValues.SetValues(entityToUpdate);
            dbEntityEntry.State = EntityState.Modified;
            _dbContextReestr.SaveChanges();
        }
        #endregion

        public async Task<T> FirstOrDefaultAsyncInclude(Expression<Func<T, bool>> filter, string childrenOne)
        {
            return await _dbSet.Include(childrenOne).FirstOrDefaultAsync(filter);
        }

        public async Task<T> FirstOrDefaultAsyncInclude(Expression<Func<T, bool>> filter, string childrenOne, string childrenTwo)
        {
            return await _dbSet.Include(childrenOne).Include(childrenTwo).FirstOrDefaultAsync(filter);
        }

        public async Task<T> FirstOrDefaultAsyncInclude(Expression<Func<T, bool>> filter, string childrenOne, string childrenTwo, string childrenThree)
        {
            return await _dbSet.Include(childrenOne).Include(childrenTwo).Include(childrenThree).FirstOrDefaultAsync(filter);
        }

        public async Task<T> FirstOrDefaultAsyncInclude(Expression<Func<T, bool>> filter, string childrenOne, string childrenTwo, string childrenThree, string childrenFour)
        {
            return await _dbSet.Include(childrenOne).Include(childrenTwo).Include(childrenThree).Include(childrenFour).FirstOrDefaultAsync(filter);
        }

        public async Task<IEnumerable<T>> Get()
        {
            Lazy<T> lazy = new Lazy<T>();

            var query = await _dbSet.AsEnumerable<T>()
                                    .AsQueryable()
                                    .AsNoTracking()
                                    .ToListAsync();

            return query;
        }

        public async Task<T> GetById(int? id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> QueryObjectGraph(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.Where(filter).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> QueryObjectGraph(Expression<Func<T, bool>> filter, string children)
        {
            return await _dbSet.Include(children).Where(filter).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> QueryObjectGraph(Expression<Func<T, bool>> filter, string children, string childrenTwo)
        {
            return await _dbSet.Include(children).Include(childrenTwo).Where(filter).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> QueryObjectGraph(Expression<Func<T, bool>> filter, string children, string childrenTwo, string childrenThree)
        {
            return await _dbSet.Include(children).Include(childrenTwo).Include(childrenThree).Where(filter).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> QueryObjectGraph(Expression<Func<T, bool>> filter, string children, string childrenTwo, string childrenThree, string childrenFour)
        {
            return await _dbSet.Include(children).Include(childrenTwo).Include(childrenThree).Include(childrenFour).Where(filter).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> QueryObjectGraph(Expression<Func<T, bool>> filter, string children, string childrenTwo, string childrenThree, string childrenFour, string childrenFive)
        {
            return await _dbSet.Include(children).Include(childrenTwo).Include(childrenThree).Include(childrenFour).Include(childrenFive).Where(filter).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetInclude(string children)
        {
            return await _dbSet.Include(children).AsNoTracking().AsEnumerable<T>().AsQueryable().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetInclude(string children, string childrenTwo)
        {
            return await _dbSet.Include(children).Include(childrenTwo).AsNoTracking().AsEnumerable<T>().AsQueryable().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetInclude(string children, string childrenTwo, string childrenThree)
        {
            return await _dbSet.Include(children).Include(childrenTwo).Include(childrenThree).AsNoTracking().AsEnumerable<T>().AsQueryable().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetInclude(string children, string childrenTwo, string childrenThree, string childrenFour)
        {
            return await _dbSet.Include(children).Include(childrenTwo).Include(childrenThree).Include(childrenFour).AsNoTracking().AsEnumerable<T>().AsQueryable().ToListAsync();
        }

    }
}
