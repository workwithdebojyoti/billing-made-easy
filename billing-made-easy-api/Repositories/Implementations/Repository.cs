using billing_made_easy_api.Models;
using billing_made_easy_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billing_made_easy_api.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly easybillContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(easybillContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await entities.ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
            return await entities.FindAsync(id);
        }
        public async Task Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            await entities.AddAsync(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            entities.Update(entity);
            context.SaveChanges();
        }
        public async Task Delete(int id)
        {
            if (id == 0) throw new ArgumentNullException("entity");

            T entity = await entities.FindAsync(id);
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
