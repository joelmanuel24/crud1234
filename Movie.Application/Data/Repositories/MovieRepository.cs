using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Data.Repositories
{
    public class MovieRepository : IRepository<Entities.Movie>
    {
        private readonly MovieDbContext dbContext;

        public MovieRepository(MovieDbContext dbContext)
        {
            if (dbContext == null) ArgumentNullException.ThrowIfNull(nameof(dbContext));
            dbContext.Database.EnsureCreated();
            this.dbContext = dbContext;
        }

        public async Task<Entities.Movie> Create(Entities.Movie entity)
        {
            await dbContext.Movies.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(Entities.Movie entity)
        {
            dbContext.Movies.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IList<Entities.Movie>> GetAll()
        {
            return await dbContext.Movies.Include(x => x.Category).AsNoTracking().ToListAsync();
        }

        public async Task<Entities.Movie> GetById(int id)
        {
            return await dbContext.Movies.Include(x => x.Category).FirstOrDefaultAsync(x => x.MovieID == id);
        }

        public async Task<Entities.Movie> Update(Entities.Movie entity)
        {
            dbContext.Movies.Update(entity);

            await dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
