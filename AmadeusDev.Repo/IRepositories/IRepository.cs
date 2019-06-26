using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static Jasarsoft.AmadeusDev.Repo.Helper.Enumerations;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface IRepository<TEntity, TPk> where TEntity : class
    {
        //all
        bool All(Expression<Func<TEntity, bool>> predicate);
        Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate);
        //any
        bool Any(Expression<Func<TEntity, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        //count
        int Count();
        int Count(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        //select
        IEnumerable<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> predicate);
        //where        
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        //find
        TEntity Find(TPk id);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindAsync(params object[] param);
        //single or default
        TEntity SingleOrDefault();
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        //first
        TEntity First();
        TEntity First(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstAsync();
        //add
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entity);
        //update
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entity);
        //remove
        void Remove(TPk id);
        void Remove(TEntity entity);        
        void RemoveRange(IEnumerable<TEntity> entities);        
        
        //get
        IEnumerable<TEntity> GetRange(int start, int take);
        //sort and range
        IEnumerable<TEntity> SortAndGetRange<TKey>(int start, int take, Expression<Func<TEntity, TKey>> predicate, OrderBy order);
        Task<IEnumerable<TEntity>> SortAndGetRangeAsync<TKey>(int start, int take, Expression<Func<TEntity, TKey>> predicate, OrderBy order);
    }
}
