using System;

namespace FinancesApi.Entities {
    public interface IEntity {
        Guid Id { get; set; }
    }
}