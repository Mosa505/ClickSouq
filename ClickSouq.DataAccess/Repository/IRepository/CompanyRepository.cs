using BookNest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookNest.DataAccess.Repository.IRepository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _repository;

        public CompanyRepository(ApplicationDbContext repository) : base(repository)
        {
            _repository = repository;
        }
        public void Update(Company Newcompany)
        {
            var Oldcompany = _repository.companies.FirstOrDefault(e => e.Id == Newcompany.Id);
            if (Oldcompany != null)
            {
                Oldcompany.Id = Newcompany.Id;
                Oldcompany.Name = Newcompany.Name;
                Oldcompany.State = Newcompany.State;
                Oldcompany.StreetAddress = Newcompany.StreetAddress;
                Oldcompany.City = Newcompany.City;
                Oldcompany.PhoneNumber = Newcompany.PhoneNumber;

            }
        }
    }
}
