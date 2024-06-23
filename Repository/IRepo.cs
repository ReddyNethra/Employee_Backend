namespace Employee_API.Repository
{
    public interface IRepo<T> where T : class
    { 
            Task CreateAsync(T entity);
            Task DeleteAsync(int id);
            Task<List<T>> GetAllAsync();
            Task<T> GetAllAsyncById(int id);
            Task SaveAsync();
            Task UpdateASync(T entity);
    }
}
