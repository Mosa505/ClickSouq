using ClickSouq.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClickSouq.DataAccess.Repository
{
    internal class Repository<T> : IRepository<T> where T : class
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

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = Dbset;
            query = query.Where(filter);
            return query.FirstOrDefault();
          
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = Dbset;
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
