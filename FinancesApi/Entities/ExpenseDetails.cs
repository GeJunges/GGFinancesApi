using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancesApi.Entities {
    public class ExpenseDetails : IEntity {

        public Guid Id { get; set; }
        [ForeignKey("ExpenseDateId")]
        public Guid ExpenseDateId { get; set; }
        [Required]
        public virtual Detail Detail { get; set; }
        public double Value { get; set; }
        public bool Paid { get; set; }
    }
}