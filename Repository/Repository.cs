
using Common.Responses;
using DatabaseContext;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        protected readonly POSContext Context;

        public Repository(POSContext context)
        {
            Context = context;

        }

        public virtual DbSet<TEntity> DbSet => Context.Set<TEntity>();

        public async Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var savedEntity = DbSet.Add(entity).Entity;

            if (autoSave)
            {
                await Context.SaveChangesAsync(cancellationToken);
            }

            return savedEntity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            Context.Attach(entity);

            var updatedEntity = Context.Update(entity).Entity;

            if (autoSave)
            {
                await Context.SaveChangesAsync(cancellationToken);
            }

            return updatedEntity;
        }

        public async Task DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            DbSet.Remove(entity);

            if (autoSave)
            {
                await Context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<List<TEntity>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = default, 
            params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            return includeDetails
                ? await WithDetails(propertySelectors).ToListAsync(cancellationToken)
                : await DbSet.ToListAsync(cancellationToken);
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, 
            bool includeDetails = false, CancellationToken cancellationToken = default,
            params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            return includeDetails
                ? await WithDetails(propertySelectors)
                 .Where(predicate)
                 .ToListAsync(cancellationToken)
                : await DbSet
                 .Where(predicate)
                 .ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(Expression<Func<TEntity, bool>> predicate=null,CancellationToken cancellationToken = default)
        {
            if (predicate == null)
            {
                return await DbSet.LongCountAsync(cancellationToken);
            }
            else
            {
                return await DbSet.Where(predicate).LongCountAsync(cancellationToken);
            }
        }

        public async Task<Result<TEntity>> GetPagedListAsync(
            int pageNo = 1,
            int pageSize = 10,
            bool isAscending = true,
            string sorting = "",
            bool includeDetails = false,
            CancellationToken cancellationToken = default,
            params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            var result = new Result<TEntity>();

            var queryable = includeDetails ? WithDetails(propertySelectors) : DbSet;

            if (!string.IsNullOrEmpty(sorting))
            {
                var sortColumn = sorting;

                if (!isAscending)
                    sortColumn += " desc";

                queryable = queryable.OrderBy(sortColumn);
            }

            List<TEntity> pagedResult = null;

            if (pageNo == 0)
                pagedResult = await queryable.ToListAsync();
            else
            {
                pagedResult = await queryable
                    .PageBy(pageNo * pageSize, pageSize)
                    .ToListAsync(cancellationToken);
            }

            result.results = pagedResult;
            result.totalCount = await GetCountAsync();

            return result;
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return DbSet.AsQueryable();
        }

        public  TEntity GetDataFromProc(string procName,SqlParameter[] param)
        {
            return  Context.Set<TEntity>().FromSqlRaw(procName, param).AsNoTracking().AsEnumerable<TEntity>().FirstOrDefault(); 
        }

        public async Task<TEntity> FindAsync(
            Expression<Func<TEntity, bool>> predicate,
            bool includeDetails = true,
            CancellationToken cancellationToken = default,
            params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            return includeDetails
                ? await WithDetails(propertySelectors)
                    .Where(predicate)
                    .SingleOrDefaultAsync(cancellationToken)
                : await DbSet
                    .Where(predicate)
                    .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var entities = await GetQueryable()
                .Where(predicate)
                .ToListAsync(cancellationToken);

            foreach (var entity in entities)
            {
                DbSet.Remove(entity);
            }

            if (autoSave)
            {
                await Context.SaveChangesAsync(cancellationToken);
            }
        }
        

        public IQueryable<TEntity> WithDetails(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            var query = GetQueryable();

            if (propertySelectors != null)
            {
                foreach (var propertySelector in propertySelectors)
                {
                    query = query.Include(propertySelector);
                }
            }

            return query;
        }
        public async Task<TEntity> GetAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }


        public IAsyncEnumerator<TEntity> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return DbSet.AsAsyncEnumerable().GetAsyncEnumerator(cancellationToken);
        }
         

        public async Task<TEntity> Get(int id)
        {

            return await Context.Set<TEntity>().FindAsync(id); 
        }

        public async Task<Result<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate, int pageNo = 1, int pageSize = 0)
        {

            var result = new Result<TEntity>();
            result.totalCount = await Context.Set<TEntity>().CountAsync();
            if (pageSize == 0)
            {
                result.results = await Context.Set<TEntity>().ToListAsync();

            }
            else
            {
                var skipEntities = (pageNo - 1) * pageSize;
                if (predicate != null )
                    result.results = await Context.Set<TEntity>().Where(predicate).Skip(skipEntities).Take(pageSize).ToListAsync();
                else
                result.results = await Context.Set<TEntity>().Skip(skipEntities).Take(pageSize).ToListAsync();
                
            }

            return result;
        }

        public async Task< IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return  await Context.Set<TEntity>().Where(predicate).ToListAsync();
           
        }

        public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return  await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> Add(TEntity entity)
        {
         await Context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
             Context.Set<TEntity>().Update(entity);
            return entity;
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
           await Context.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task BulkInsert(IList<TEntity> entities)
        {
          await Context.BulkInsertAsync(entities);
        }

        public virtual  async Task<int> Remove(TEntity entity)
        {
             Context.Set<TEntity>().Remove(entity);
          return await Context.SaveChangesAsync();

        }

        public async Task<int> RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
            return await Context.SaveChangesAsync();
        }

       
    }
}
