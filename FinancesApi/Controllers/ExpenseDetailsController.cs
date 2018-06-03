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
    [Route("api/details")]
    public class ExpenseDetailsController: Controller {
        private readonly IExpensesDetailsRepository _repository;
        private IMapper _mapper;

        public ExpenseDetailsController(IExpensesDetailsRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) {

            var entity = await _repository.FindExpensesDetail(id);
            var expenseDetailDto = _mapper.Map<ExpenseDetails>(entity);

            return new JsonResult(expenseDetailDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetExpenseDate([FromQuery(Name ="expenseDate")]Guid id) {
            var details = await _repository.FindDetailsByExpenseDateId(id);
            var detailsDtoList = _mapper.Map<List<ExpenseDetailsDto>>(details);
            return new JsonResult(detailsDtoList);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExpenseDetailsDto expenseDetailsDto) {

            var entity = _mapper.Map<ExpenseDetails>(expenseDetailsDto);
            await _repository.Add(entity);

            var dto = _mapper.Map<ExpenseDetailsDto>(entity);
            return new JsonResult(dto);
        }
    }
}
