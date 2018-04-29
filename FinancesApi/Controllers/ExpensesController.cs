using AutoMapper;
using FinancesApi.Entities;
using FinancesApi.Model;
using FinancesApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancesApi.Controllers {
    //[Authorize]
    [Route("api/expenses")]
    public class ExpensesController {
        private readonly IExpensesRepository _repository;
        private IMapper _mapper;

        public ExpensesController(IExpensesRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery]Budget budget, [FromQuery]DateTime date) {

            var expensesByDate = await _repository.FindExpensesDate(budget, date);

            var expensesDateDtoList = _mapper.Map<List<ExpenseDateDto>>(expensesByDate);

            return new JsonResult(expensesByDate);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExpenseDateDto expenseDateDto) {

            var entity = _mapper.Map<ExpenseDate>(expenseDateDto);
            await _repository.Add(entity);

            var dto = _mapper.Map<ExpenseDateDto>(entity);
            return new JsonResult(dto);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id) {
            var entity = await _repository.FindExpenseDate(Id);

            if (entity == null) {
                return new BadRequestResult();
            }

            _repository.Delete(entity);

            return new OkResult();
        }
    }
}
