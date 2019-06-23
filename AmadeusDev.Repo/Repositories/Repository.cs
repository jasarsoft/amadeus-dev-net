using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jasarsoft.AmadeusDev.Repo.Context;
using Jasarsoft.AmadeusDev.Repo.IRepositories;

namespace Jasarsoft.AmadeusDev.Repo.Repositories
{
    public class Repository<TEntity, TPk> : IRepository<TEntity, TPk> where TEntity : class
    {
        protected readonly DbSet<TEntity> entity;
        protected readonly AmadeusDevContext context;

        public Repository(AmadeusDevContext context)
        {
            this.context = context;
            this.entity = context.Set<TEntity>();
        }

        #region All
        virtual public bool All(Expression<Func<TEntity, bool>> predicate)
        {
            return entity.All(predicate);
        }

        virtual public async Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await entity.AllAsync(predicate);
        }
        #endregion

        #region Any
        virtual public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return entity.Any(predicate);
        }

        virtual public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await entity.AnyAsync(predicate);
        }
        #endregion

        #region Add
        virtual public void Add(TEntity entity)
        {
            this.entity.Add(entity);
        }

        virtual public void AddRange(IEnumerable<TEntity> entities)
        {
            this.entity.AddRange(entities);
        }
        #endregion

        #region Count
        virtual public int Count()
        {
            return entity.Count();
        }

        virtual public async Task<int> CountAsync()
        {
            return await entity.CountAsync();
        }

        virtual public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return entity.Where(predicate).Count();
        }

        virtual public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await entity.Where(predicate).CountAsync();
        }
        #endregion


        #region Find
        virtual public TEntity Find(TPk id)
        {
            return entity.Find(id);   
        }

        virtual public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return entity.Find(predicate);
        }

        virtual public async Task<TEntity> FindAsync(params object[] param)
        {
            return await entity.FindAsync(param);
        }
        #endregion

        #region First
        virtual public TEntity First()
        {
            return entity.First();
        }

        virtual public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return entity.First(predicate);
        }

        virtual public async Task<TEntity> FirstAsync()
        {
            return await entity.FirstAsync();
        }
        #endregion
       
        #region Remove
        virtual public void Remove(TPk id)
        {
            TEntity e = entity.Find(id);
            entity.Remove(e);
        }

        virtual public void Remove(TEntity entity)
        {
            this.entity.Remove(entity);
        }

        virtual public void RemoveRange(IEnumerable<TEntity> entities)
        {
            entity.RemoveRange(entities);
        }
        #endregion

        #region Update
        virtual public void Update(TEntity entity)
        {
            this.entity.Update(entity);
        }

        virtual public void UpdateRange(IEnumerable<TEntity> entities)
        {
            entity.UpdateRange(entities);
        }
        #endregion

        #region Select
        virtual public IEnumerable<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> predicate)
        {
            return entity.Select(predicate);
        }
        #endregion

        #region Where
        virtual public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return entity.Where(predicate);
        }
        #endregion

        #region SingeOrDefault
        virtual public TEntity SingleOrDefault()
        {
            return entity.SingleOrDefault();
        }

        virtual public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return entity.SingleOrDefault(predicate);
        }
        #endregion

        #region GetRegion
        virtual public IEnumerable<TEntity> GetRange(int start, int take)
        {
            return entity.Skip(start).Take(take);
        }
        #endregion
    }
}
