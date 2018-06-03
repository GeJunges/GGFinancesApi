using System.Collections.Generic;
using System.Threading.Tasks;
using FinancesApi.Entities;

namespace FinancesApi.Repositories {
    public interface IRegisterRepository {
        Task<ICollection<Register>> Find(Budget budget);
    }
}