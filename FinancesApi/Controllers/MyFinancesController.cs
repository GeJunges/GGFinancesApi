using AutoMapper;
using FinancesApi.Model;
using FinancesApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancesApi.Controllers {
    //[Authorize]
    [Route("api/myfinances")]
    public class MyFinancesController : Controller {

        private readonly IDetailsRepository _detailsRepository;
        private readonly IIncomesDateRepository _incomesRepository;
        private readonly IExpensesDateRepository _expensesRepository;
        private IMapper _mapper;

        public MyFinancesController(IMapper mapper,
            IDetailsRepository detailsRepository,
            IIncomesDateRepository incomesRepository,
            IExpensesDateRepository expensesRepository) {
            _mapper = mapper;
            _detailsRepository = detailsRepository;
            _incomesRepository = incomesRepository;
            _expensesRepository = expensesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery(Name = "date")]DateTime date) {
            var myFinances = new MyFinancesDto();

            var incomesEntities = await _incomesRepository.FindByDate(date);
            var incomesDto = _mapper.Map<List<IncomeDateDto>>(incomesEntities);

            var expensesEntities = await _expensesRepository.FindByDate(date);
            var expensesDto = _mapper.Map<List<ExpenseDateDto>>(expensesEntities);

            myFinances.Incomes.Details.AddRange(incomesDto);
            myFinances.Expenses.ExpensesList.AddRange(expensesDto);

            return new JsonResult(myFinances);
        }
    }
}
