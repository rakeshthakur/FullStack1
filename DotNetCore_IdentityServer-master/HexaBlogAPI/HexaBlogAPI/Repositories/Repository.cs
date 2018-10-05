using HexaBlogAPI.Infrastructure;
using HexaBlogAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HexaBlogAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {

        private readonly BlogsContext db;
        private readonly DbSet<T> entities;

        public Repository(BlogsContext dbContext)
        {
            this.db = dbContext;
            this.entities = dbContext.Set<T>();            
        }

        public async Task<T> AddAsync(T item)
        {
            this.entities.Add(item);
            await db.SaveChangesAsync();
            return item;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var item= await this.entities.FindAsync(id);
            if (item != null)
            {
                this.entities.Remove(item);
                await this.db.SaveChangesAsync();
            }
            return item;
        }

        public IEnumerable<T> GetAll()
        {
            return this.entities.ToList();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this.entities.FindAsync(id);
        }

        public async Task<T> UpdateAsync(int id, T item)
        {
            if (id != item.Id)
            {
                throw new Exception("item with given id not found");
            }
            var result=this.entities.Update(item);
            await db.SaveChangesAsync();
            return result.Entity;
        }
    }
}
