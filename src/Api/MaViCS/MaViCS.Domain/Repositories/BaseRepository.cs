﻿using Microsoft.EntityFrameworkCore;
using QuickStars.MaViCS.Domain.Data;
using QuickStars.MaViCS.Domain.Data.Entities;
using QuickStars.MaViCS.Domain.Interfaces;
using System.Linq.Expressions;

namespace QuickStars.MaViCS.Domain.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DatabaseContext _databaseContext;

        public BaseRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public virtual async Task<IEnumerable<T>> GetAll(bool ignoreArchived = true, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _databaseContext.Set<T>();

            foreach (var include in includes)
                query = query.Include(include);

            if (ignoreArchived) query = query.Where(e => e.DeletedOn == null);

            return await query.ToListAsync();
        }

        public virtual async Task<T?> GetById(long id, bool ignoreArchived = true, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _databaseContext.Set<T>();

            foreach (var include in includes)
                query = query.Include(include);

            if (ignoreArchived) query = query.Where(e => e.DeletedOn == null);

            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task<T?> Create(T entity)
        {
            var entry = await _databaseContext.Set<T>().AddAsync(entity);
            await _databaseContext.SaveChangesAsync();

            return entry.Entity;
        }

        public virtual async Task<T?> Update(T entity)
        {
            var entry = _databaseContext.Set<T>().Update(entity);
            await _databaseContext.SaveChangesAsync();

            return entry.Entity;
        }

        public virtual async Task<bool> Archive(long id)
        {
            var entity = await _databaseContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);

            if (entity is null || entity.DeletedOn is not null) return false;

            entity.DeletedOn = DateTime.UtcNow;
            entity.DeletedBy = "Application";

            _databaseContext.Set<T>().Update(entity);
            await _databaseContext.SaveChangesAsync();

            return true;
        }

        public virtual async Task<bool> Delete(long id)
        {
            var entity = await _databaseContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);

            if (entity is null) return false;

            _databaseContext.Set<T>().Remove(entity);
            await _databaseContext.SaveChangesAsync();

            return true;
        }

    }
}
