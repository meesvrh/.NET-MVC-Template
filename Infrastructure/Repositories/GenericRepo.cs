using Domain.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public abstract class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly BusinessContext _context;
        private readonly DbSet<T> _entity;
        
        public GenericRepo(BusinessContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public IQueryable<T> GetAll() => _entity;

        public async Task<T> GetByIdAsync(int id) => await _entity.FindAsync(id);

        public T GetById(int id) => _entity.Find(id);

        public void Insert(T obj) => _entity.Add(obj);

        public void Remove(T obj) => _entity.Remove(obj);

        public void Update(T obj) => _entity.Update(obj);
    }
}
