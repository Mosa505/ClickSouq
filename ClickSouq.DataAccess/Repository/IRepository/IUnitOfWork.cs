using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookNest.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public ICategoryRepository Category { get; }
        public IProductRepository Product { get; }
        public ICompanyRepository Company { get; }
        public IShoppingCart ShoppingCart { get; }
        public IApplicationUser ApplicationUser { get; }
        public IOrderHeaderRepository OrderHeader  { get; }
        public IOrderDetailRepository OrderDetail { get; }
        void Save();


    }
}
