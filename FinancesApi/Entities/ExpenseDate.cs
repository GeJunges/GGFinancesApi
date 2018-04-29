using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinancesApi.Entities {
    public class ExpenseDate : IEntity {

        public Guid Id { get; set; }
        [Required]
        public virtual Expense Expense { get; set; }
        public DateTime Date { get; set; }
        public List<ExpenseDetails> ExpenseDetails { get; set; }
    }
}