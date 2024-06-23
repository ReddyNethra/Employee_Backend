using Employee_API.Repository.Database;
using Microsoft.EntityFrameworkCore;

namespace Employee_API.Repository
{
    public class Repo<T>: IRepo<T> where T : class
    {

        private readonly ApplicationDbContext _context;
        public Repo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();

        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var std = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(std);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetAllAsyncById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateASync(T entity)
        {
            _context.Update(entity);
            await SaveAsync();
        }
    }
}
