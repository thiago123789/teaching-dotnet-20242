using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NGPD.Manager.CrossCutting.Extensions;
using NGPD.Manager.Data.Contracts.Base;
using NGPD.Manager.Entities.Base;
using NGPD.Manager.Entities.Pagination;

namespace NGPD.Manager.Data;

public abstract class Repository<T> : IRepository<T>
        where T : BaseEntity, new()
    {
        protected ManagerDbContext _entities;
        protected readonly DbSet<T> _context;

        protected Repository(ManagerDbContext dbContext)
        {
            _entities = dbContext;
            _context = _entities.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate, 
            bool includeDeleted = false, bool eager = false)
        {
            var query = this.Query(eager).Select(e => e);

            if (!includeDeleted)
            {
                query = query.Where(e => e.IsDeleted || !e.IsDeleted);
            }
            else
            {
                query = query.Where(e => !e.IsDeleted);
            }
            return await query.Where(predicate).ToListAsync<T>();
        }

        public virtual T Delete(T entity)
        {
            entity.IsDeleted = true;
            return _context.Update(entity).Entity;
        }

        public T Update(T entity)
        {
            entity.LastModifiedDate = DateTime.Now;
            _context.Attach(entity).State = EntityState.Modified;
            return entity;
        }
        
        public virtual async Task<T> FindAsync(T entity, bool includeDeleted = false, bool eager = false)
        {
            var query = this.Query(eager).Select(e => e);

            if (includeDeleted)
            {
                query = query.Where(e => e.IsDeleted || !e.IsDeleted);
            }
            else
            {
                query = query.Where(e => !e.IsDeleted);
            }

            query = query.Where(e => e.Equals(entity));

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<T> FindByIdAsync(Guid id, bool includeDeleted = false)
        {
            return await _context.FindAsync(id);
        }

        public async Task<PagedResult<T>> GetActiveElementsPagedResultAsync(PaginationFilter filter)
        {
            var query = this.Query(true).Where(e => !e.IsDeleted);

            if (!string.IsNullOrEmpty(filter.Sort))
            {
                if(filter.Sort == OrderTypeEnum.ASC.GetEnumDescription())
                {
                    query = query.OrderBy(e => e);
                }else if (filter.Sort == OrderTypeEnum.DESC.GetEnumDescription())
                {
                    query = query.OrderByDescending(e => e);
                }
         
            }

            return await query.PaginateAsync(filter);
        }

        public virtual T UnDelete(Guid id)
        {
            var entity = _context.Find(id);
            entity.LastModifiedDate = DateTime.Now;
            entity.IsDeleted = false;
            return this.Update(entity);
        }

        public virtual async Task<IEnumerable<T>> FindAllAsync(bool includeDeleted = false)
        {
            var query = this.Query(true).Select(e => e);

            if (includeDeleted)
            {
                query = query.Where(e => e.IsDeleted || !e.IsDeleted);
            }
            else
            {
                query = query.Where(e => !e.IsDeleted);
            }
            return await query.ToListAsync<T>();
        }

        public virtual async Task<T> SaveAsync(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            await _context.AddAsync(entity);
            return entity;
        }

        public async Task<PagedResult<T>> FindAllByPagedAsync(PaginationFilter filter, bool includeDeleted = false)
        {
            var query = this.Query(true).Select(e => e);

            if (includeDeleted)
            {
                query = query.Where(e => e.IsDeleted && !e.IsDeleted);
            }
            else
            {
                query = query.Where(e => !e.IsDeleted);
            }

            if (!string.IsNullOrEmpty(filter.Sort))
            {
                if (filter.Sort == OrderTypeEnum.ASC.GetEnumDescription())
                {
                    query = query.OrderBy(e => e);
                }
                else if (filter.Sort == OrderTypeEnum.DESC.GetEnumDescription())
                {
                    query = query.OrderByDescending(e => e);
                }
            }

            return await query.PaginateAsync(filter);
        }
        
        private IQueryable<T> Query(bool eager = false)
        {
            var query = _context.AsQueryable();
            if (eager)
            {
                foreach (var property in _entities.Model.FindEntityType(typeof(T)).GetNavigations())
                    query = query.Include(property.Name);
            }
            return query;
        }

    }