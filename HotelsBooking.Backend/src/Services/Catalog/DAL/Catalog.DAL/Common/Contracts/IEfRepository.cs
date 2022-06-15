using Catalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Catalog.DAL.Common.Contracts
{
    public interface IEfRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity objModel);
        void AddRange(IEnumerable<TEntity> objModel);
        TEntity GetId(int id);
        Task<TEntity> GetIdAsync(int id);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        int Count();
        Task<int> CountAsync();
        void Update(TEntity objModel);
        void Remove(TEntity objModel);
        void Dispose();
    }
}
