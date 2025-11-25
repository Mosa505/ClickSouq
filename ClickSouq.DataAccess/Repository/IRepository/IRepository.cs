using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookNest.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter=null, string? IncludeProperties = null);
        T Get(Expression<Func<T, bool>> filter, string? IncludeProperties = null, bool Track = false);
        void Add(T item);
        void Remove(T item);
        void RemoveRange(IEnumerable<T> Items);

    }
}
