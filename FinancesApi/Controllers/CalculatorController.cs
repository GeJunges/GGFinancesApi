using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinancesApi.Strategy;

namespace FinancesApi.Controllers {

    [Route("api/Calculator")]
    public class CalculatorController : ControllerBase {

        private readonly IAveragingMethod _averagingMethod;
        public CalculatorController(IAveragingMethod averagingMethod) {
            _averagingMethod = averagingMethod;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TypeOfCalc type) {
            var values = new List<int> { 9, 8, 7 };
            var strategy = new CalculatorFactory().Create(type);
            var result = strategy.AverageFor(values);

            return new JsonResult(result);
        }
    }
}