using System;

namespace FinancesApi.Model {
    public class ExpenseDateDto {
        public string Id { get; set; }
        public ExpenseDto ExpenseDto { get; set; }
        public DateTime Date { get; set; }
    }
}