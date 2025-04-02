using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Models.Repositories.Interfaces;
using Shared.Models.UtilitiesShared;

namespace Shared.Models.Repositories
{
    public abstract class BaseCrudRepository<TEntity, TKey> : ICrudRepository<TEntity, TKey>
     where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseCrudRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            if (typeof(BaseEntity<TKey>).IsAssignableFrom(typeof(TEntity)))
            {
                return await _dbSet
                    .AsNoTracking()
                    .Where(e => EF.Property<bool>(e, "IsActive") == true)
                    .ToListAsync();
            }

            return await _dbSet.AsNoTracking().ToListAsync();
        }


        public virtual async Task<TEntity?> GetByIdAsync(TKey id)
        {
            if (typeof(BaseEntity<TKey>).IsAssignableFrom(typeof(TEntity)))
            {
                return await _dbSet
                    .Where(e => EF.Property<TKey>(e, "Id")!.Equals(id)
                             && EF.Property<bool>(e, "IsActive") == true)
                    .FirstOrDefaultAsync();
            }

            return await _dbSet.FindAsync(id); 
        }


        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChangesAsync(); 
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await SaveChangesAsync(); 
            return entity;
        }

        public virtual async Task<bool> DeleteAsync(TKey id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;

            if (entity is BaseEntity<TKey> baseEntity)
            {
                baseEntity.IsActive = false;
                baseEntity.DeletedAt = DateTime.UtcNow;
            }

            await SaveChangesAsync();
            return true;
        }


        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
