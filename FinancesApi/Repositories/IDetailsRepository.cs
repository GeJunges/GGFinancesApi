using System.Collections.Generic;
using System.Threading.Tasks;
using FinancesApi.Entities;

namespace FinancesApi.Repositories {
    public interface IDetailsRepository {
        Task<ICollection<Detail>> Find();
    }
}