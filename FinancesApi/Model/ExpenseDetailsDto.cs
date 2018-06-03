using System;

namespace FinancesApi.Model {
    public class ExpenseDetailsDto {
        public string Id { get; set; }
        public string ExpenseDateId { get; set; }
        public DetailDto DetailDto { get; set; }
        public double? Value { get; set; }
        public bool Paid { get; set; }
    }
}