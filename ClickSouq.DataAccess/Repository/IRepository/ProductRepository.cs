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
        public ProductRepository(ApplicationDbContext repository) : base(repository)
        {
            _repository = repository;
        }
        public void Update(Product Newproduct)
        {
            var OldProduct = _repository.Products.FirstOrDefault(e => e.Id == Newproduct.Id);
            if (OldProduct != null)
            {
                OldProduct.Title = Newproduct.Title;
                OldProduct.ISBN = Newproduct.ISBN;
                OldProduct.Author = Newproduct.Author;
                OldProduct.Description = Newproduct.Description;
                OldProduct.ListPrice = Newproduct.ListPrice;
                OldProduct.Price = Newproduct.Price;
                OldProduct.Price50 = Newproduct.Price50;
                OldProduct.Price100 = Newproduct.Price100;

                if (Newproduct.ImageURL != null)
                {
                    OldProduct.ImageURL = Newproduct.ImageURL;
                }

            }
        }
    }
}
