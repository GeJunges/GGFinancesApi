using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinancesApi.Entities;

namespace FinancesApi.Controllers {

    [Route("api/Calculator")]
    public class CalculatorController : ControllerBase {
      
        public CalculatorController() {
        }

        [HttpGet("{type}")]
        public async Task<IActionResult> Get() {

            return Ok();
        }
    }
}