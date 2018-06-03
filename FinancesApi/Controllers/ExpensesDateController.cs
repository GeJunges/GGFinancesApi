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
    public class ExpensesDateController : Controller {
        private readonly IExpensesDateRepository _repository;
        private IMapper _mapper;

        public ExpensesDateController(IExpensesDateRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery(Name = "date")]DateTime date) {

            var entities = await _repository.FindByDate(date);

            var expensesDateDto = _mapper.Map<List<ExpenseDateDto>>(entities);

            return new JsonResult(expensesDateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExpenseDateDto expenseDateDto) {

            var entity = _mapper.Map<ExpenseDate>(expenseDateDto);
            await _repository.Add(entity);

            var dto = _mapper.Map<ExpenseDateDto>(entity);
            return new JsonResult(dto);
        }
    }
}
