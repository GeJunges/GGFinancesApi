using System.Threading.Tasks;
using FinancesApi.Entities;

namespace FinancesApi.Repositories {
    public interface IPersistenceRepository<T> where T : IEntity {
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}