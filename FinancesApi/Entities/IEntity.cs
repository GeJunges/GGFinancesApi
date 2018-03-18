using System;

namespace FinancesApi.Entities {
    public interface IEntity {
        int Id { get; set; }
        Guid Identifier { get; set; }
    }
}