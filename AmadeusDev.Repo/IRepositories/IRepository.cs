using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface IRepository<TEntity, TPk> where TEntity : class
    {
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
        //all
        bool All(Expression<Func<TEntity, bool>> predicate);
        //any
        bool Any(Expression<Func<TEntity, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
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
        //count
        int Count();
        int Count(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync();

        //get
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetRange(int start, int take);  
    }
}
