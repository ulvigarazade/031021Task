using DataAccessLayer.Interfaces;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementations
{
    public class JsonRepository<T> : IRepository<T> where T : class, IEntity
    {
        public Task<bool> CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(params T[] entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(params T[] entities)
        {
            throw new NotImplementedException();
        }
    }
}
