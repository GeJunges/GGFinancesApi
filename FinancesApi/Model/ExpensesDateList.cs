using System.Collections.Generic;
using System.Linq;

namespace FinancesApi.Model {
    public class ExpensesDateList {

        public List<ExpenseDateDto> ExpensesList { get; set; }

        public virtual double? Total {
            get {
                if (ExpensesList.Count > 0) {
                    return ExpensesList.Sum(d => d?.Total);
                }
                return null;
            }
        }

        public ExpensesDateList() {
            ExpensesList = new List<ExpenseDateDto>();
        }
    }
}