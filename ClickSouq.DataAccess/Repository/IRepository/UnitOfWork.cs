﻿using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookNest.DataAccess.Repository.IRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _unitDb;
        public ICategoryRepository Category { get; private set; }
        public UnitOfWork( ApplicationDbContext UnitDb)
        {
            _unitDb = UnitDb;
            Category =new CategoryRepository(_unitDb);
        }
        public void Save()
        {
            _unitDb.SaveChanges();

        }
    }
}
