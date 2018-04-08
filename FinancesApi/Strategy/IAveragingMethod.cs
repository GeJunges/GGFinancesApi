using System.Collections.Generic;

namespace FinancesApi.Strategy {
    public interface IAveragingMethod {
        double AverageFor(List<int> values);
    }
}