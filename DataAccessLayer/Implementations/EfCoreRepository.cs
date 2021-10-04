using DataAccessLayer.Interfaces;
using Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementations
{
    public class EfCoreRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly AppDbContext Db;

        public EfCoreRepository(AppDbContext db)
        {
            Db = db;
        }
        public async Task<List<T>> GetAllAsync()
        {
            var data = await Db.Set<T>().ToListAsync();
            return data;
        }
        public async Task<T> GetAsync(int id)
        {
            var data = await Db.Set<T>().AsNoTracking().FirstOrDefaultAsync(x=> x.Id == id);

            return data;
        }
        public async Task<bool> CreateAsync(T entity)
        {
            await using var dbContextTransaction = await Db.Database.BeginTransactionAsync();
            try
            {
                await Db.Set<T>().AddAsync(entity);
                await Db.SaveChangesAsync();
                await dbContextTransaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await dbContextTransaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> CreateAsync(IEnumerable<T> entities)
        {
            await using var dbContextTransaction = await Db.Database.BeginTransactionAsync();

            try
            {
                foreach (var entity in entities)
                {
                    await Db.Set<T>().AddAsync(entity);
                    await Db.SaveChangesAsync();
                }

                await dbContextTransaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await dbContextTransaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> CreateAsync(params T[] entities)
        {
            await using var dbContextTransaction = await Db.Database.BeginTransactionAsync();
            try
            {
                foreach (var entity in entities)
                {
                    await Db.Set<T>().AddAsync(entity);
                    await Db.SaveChangesAsync();
                }

                await dbContextTransaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await dbContextTransaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            await using var dbContextTransaction = await Db.Database.BeginTransactionAsync();
            try
            {
                Db.Set<T>().Update(entity);
                await Db.SaveChangesAsync();
                await dbContextTransaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await dbContextTransaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> UpdateAsync(IEnumerable<T> entities)
        {
            await using var dbContextTransaction = await Db.Database.BeginTransactionAsync();
            try
            {
                foreach (var entity in entities)
                {
                    Db.Set<T>().Update(entity);
                    await Db.SaveChangesAsync();
                }

                await dbContextTransaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await dbContextTransaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> UpdateAsync(params T[] entities)
        {
            await using var dbContextTransaction = await Db.Database.BeginTransactionAsync();
            try
            {
                foreach (var entity in entities)
                {
                    Db.Set<T>().Update(entity);
                    await Db.SaveChangesAsync();
                }

                await dbContextTransaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await dbContextTransaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            await using var dbContextTransaction = await Db.Database.BeginTransactionAsync();
            try
            {
                Db.Set<T>().Remove(entity);
                await Db.SaveChangesAsync();
                await dbContextTransaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await dbContextTransaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> DeleteAsync(IEnumerable<T> entities)
        {
            await using var dbContextTransaction = await Db.Database.BeginTransactionAsync();
            try
            {
                foreach (var entity in entities)
                {
                    Db.Set<T>().Remove(entity);
                    await Db.SaveChangesAsync();
                }

                await dbContextTransaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await dbContextTransaction.RollbackAsync();
                throw;
            }
        }
    }
}
