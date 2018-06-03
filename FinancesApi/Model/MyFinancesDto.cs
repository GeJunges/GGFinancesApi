namespace FinancesApi.Model {
    public class MyFinancesDto {

        public IncomesList Incomes { get; set; }

        public ExpensesDateList Expenses { get; set; }

        public Balance Balance { get; set; }

        public MyFinancesDto() {
            Incomes = new IncomesList();
            Expenses = new ExpensesDateList();
            Balance = new Balance();
        }
    }
}
