using Microsoft.EntityFrameworkCore;
using Movie.Application.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Data.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly MovieDbContext dbContext;

        public CategoryRepository(MovieDbContext dbContext)
        {
            if (dbContext == null) ArgumentNullException.ThrowIfNull(nameof(dbContext));
            this.dbContext = dbContext;
        }

        public async Task<Category> Create(Entities.Category entity)
        {
            await dbContext.Categories.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(Entities.Category entity)
        {
            dbContext.Categories.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IList<Entities.Category>> GetAll()
        {
            return await dbContext.Categories.ToListAsync();
        }

        public async Task<Entities.Category> GetById(int id)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryID == id);
        }

        public async Task<Entities.Category> Update(Entities.Category entity)
        {
            dbContext.Categories.Update(entity);

            await dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
