using BookNest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookNest.DataAccess.Repository.IRepository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository (ApplicationDbContext db) :base(db)
        {
            _db = db;
        }
        

        public void Update(Category category)
        {
            _db.Update(category);
        }
    }
}
