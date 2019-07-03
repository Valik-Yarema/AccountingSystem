using AccountingSystem.Models;
using AccountingSystem.Services.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AccountingSystem.Services.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {      
        protected readonly ApplicationDbContext context;
        private DbSet<TEntity> dbSet;
       
        public BaseRepository(ApplicationDbContext mainDbContext)
        {
            context = mainDbContext;
            dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<TEntity> GetAll(int page, int countOnPage,out int maxOfElement)
        {
            maxOfElement = dbSet.Count();
            return dbSet.Skip((page - 1) * countOnPage).Take(countOnPage).ToList();
        }

        public virtual TEntity GetById(Guid id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetFiltered(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public virtual IEnumerable<TEntity> GetFiltered(int page, int countOnPage,out int maxOfElement,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                var entity= orderBy(query);
                maxOfElement = entity.Count();
                return entity.Skip((page - 1) * countOnPage).Take(countOnPage).ToList();
            }
            else
            {
                maxOfElement = query.Count();
                return query.Skip((page - 1) * countOnPage).Take(countOnPage).ToList();
            }
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            try
            {
                dbSet.Attach(entityToUpdate);
            }
            catch { }
            finally
            {
                dbSet.Update(entityToUpdate);
            }
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public void SetStateModified(TEntity entity)
        {
            context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
