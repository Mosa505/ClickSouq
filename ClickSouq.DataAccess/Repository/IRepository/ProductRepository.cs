using BookNest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookNest.DataAccess.Repository.IRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _repository;
        public ProductRepository(ApplicationDbContext repository):base(repository) 
        {
            _repository = repository;
        }
        public void Update(Product product)
        {
            _repository.Update(product);
        }
    }
}
