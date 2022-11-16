using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IGenericRepo<T> where T : class
    {
        T GetById(int id);

        Task<T> GetByIdAsync(int id);

        IQueryable<T> GetAll();

        void Insert(T obj);

        void Remove(T obj);

        void Update(T obj);
    }
}
