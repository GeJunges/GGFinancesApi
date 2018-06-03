using System;
using System.ComponentModel.DataAnnotations;

namespace FinancesApi.Entities {
    public class IncomeDate : IEntity {

        public Guid Id { get; set; }
        [Required]
        public virtual Register Register { get; set; }
        public double? Value { get; set; }
        public DateTime Date { get; set; }

    }
}