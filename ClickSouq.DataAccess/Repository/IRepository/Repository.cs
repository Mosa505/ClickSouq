using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BookNest.DataAccess.Repository.IRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> Dbset;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            Dbset = _db.Set<T>();
            // Dbset = _db.Categories

        }
        public void Add(T item)
        {
            Dbset.Add(item);
        }

        public T Get(Expression<Func<T, bool>> filter , string? IncludeProperties = null,bool Track =false)
        {
            IQueryable<T> query;
            if (Track)
            {
                query = Dbset;
            }
            else {
                query = Dbset.AsNoTracking();
            }

            query = query.Where(filter);
            if (!string.IsNullOrEmpty(IncludeProperties))
            {
                foreach (var include in IncludeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(include);

                }

            }
            return query.FirstOrDefault();


        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter, string? IncludeProperties = null)
        {
            IQueryable<T> query = Dbset;
            if (filter != null) { query = query.Where(filter); }
           
            if (!string.IsNullOrEmpty(IncludeProperties))
            {
                foreach (var include in IncludeProperties
                    .Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(include);

                }

            }
            return query.ToList();
        }

        public void Remove(T item)
        {
            Dbset.Remove(item);
        }

        public void RemoveRange(IEnumerable<T> Items)
        {
            Dbset.AddRange(Items);
        }
    }
}
