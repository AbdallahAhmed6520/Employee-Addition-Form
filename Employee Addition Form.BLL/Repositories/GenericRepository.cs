using Demo.BLL.Interfaces;
using Employee_Addition_Form.DAL.Context;
using Employee_Addition_Form.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Demo.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(T item)
        {
            _dbContext.Add(item);
        }

        public void Delete(T item)
        {
            _dbContext.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            _dbContext.Update(item);
        }
    }
}