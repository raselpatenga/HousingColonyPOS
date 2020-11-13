using Common.Responses;
using Models.Models;
using Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<TEntity> where TEntity : BaseModel
    {
      TEntity GetDataFromProc(string procName, SqlParameter[] param);
        Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);
        Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = default,
            params Expression<Func<TEntity, object>>[] propertySelectors);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate,
            bool includeDetails = false, CancellationToken cancellationToken = default,
            params Expression<Func<TEntity, object>>[] propertySelectors);
        Task<long> GetCountAsync(Expression<Func<TEntity, bool>> predicate=null, CancellationToken cancellationToken = default);
        //Task<Result<TEntity>> GetPagedListAsync(
        //    int pageNo = 0,
        //    int pageSize = 10,
        //    bool isAscending = true,
        //    string sorting = "",
        //    bool includeDetails = false,
        //    CancellationToken cancellationToken = default,
        //    params Expression<Func<TEntity, object>>[] propertySelectors);

        IQueryable<TEntity> GetQueryable();
        Task<TEntity> FindAsync(
            Expression<Func<TEntity, bool>> predicate,
            bool includeDetails = true,
            CancellationToken cancellationToken = default,
            params Expression<Func<TEntity, object>>[] propertySelectors);
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = false, CancellationToken cancellationToken = default);
        IQueryable<TEntity> WithDetails(params Expression<Func<TEntity, object>>[] propertySelectors);

        Task<TEntity> GetAsync(int id);
        Task<TEntity> Get(int id);
        Task<Result<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate,int pageNo = 1, int pageSize = 0);
        //Task<PageResult<TEntity>> GetPage(int page, int pageSize);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Add(TEntity entity);
        TEntity Update(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);
        Task BulkInsert(IList<TEntity> entities);



        Task<int> Remove(TEntity entity);
        Task<int> RemoveRange(IEnumerable<TEntity> entities);        
    }
}
