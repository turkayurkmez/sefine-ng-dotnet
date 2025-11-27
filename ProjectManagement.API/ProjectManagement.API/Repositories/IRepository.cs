using ProjectManagement.API.Models;

namespace ProjectManagement.API.Repositories
{
	public interface IRepository<T> where T : class, IDBEntity, new()
    {
        //Tüm tablolar için ortak olan CRUD operasyonları burada tanımlanacak.
        Task<IEnumerable<T>> GetAllAsync();
		Task<T?> GetByIdAsync(int id);
		Task<T> CreateAsync(T entity);
		Task<T?> UpdateAsync(T entity);
		Task<bool> DeleteAsync(int id);

    }    
}
