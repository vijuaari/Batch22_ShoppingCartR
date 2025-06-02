﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ShoppingCartR.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;

        private DbSet<T> dbSet;

        public Repository (ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = db.Set <T> ();

        }

        public void Add(T entity)
        {
            dbSet.Add (entity);

        }

        
        public T Get(Expression<Func<T, bool>> filter = null, string? includeproperties = null,bool tracked = false )
        {
            IQueryable<T> query;
            if (tracked)
            {
                query = dbSet;
            }
            else
            {
                query = dbSet.AsNoTracking();
            }
                query = query.Where(filter);

            if (!string.IsNullOrEmpty(includeproperties))
            {
                foreach (var property in includeproperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries) )

                    {
                        query = query.Include(property);
                    }

                }
                return query.FirstOrDefault();
            }

        public IEnumerable<T> GetAllexpression(Expression<Func<T, bool>> filter = null, string? includeproperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);

            }
            if (!string.IsNullOrEmpty(includeproperties))
            {
                foreach (var property in includeproperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries) )
                    
                    {
                        query = query.Include(property);
                    }

                }
            
                return query.ToList();
            }


        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

       
    }
}
