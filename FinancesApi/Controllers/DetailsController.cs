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
    public class DetailsController {
        private readonly IDetailsRepository _repository;
        private IMapper _mapper;

        public DetailsController(IDetailsRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) {

            var details = await _repository.FindDetailsByExpenseId(id);

            var detailsDtoList = _mapper.Map<List<DetailsExpenseDto>>(details);

            return new JsonResult(detailsDtoList);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DetailsExpenseDto expenseDetailsDto) {

            var entity = _mapper.Map<ExpenseDetails>(expenseDetailsDto);
            await _repository.Add(entity);

            var dto = _mapper.Map<DetailsExpenseDto>(entity);
            return new JsonResult(dto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id) {
            var entity = await _repository.FindExpenseDetails(Id);

            if (entity == null) {
                return new BadRequestResult();
            }

            _repository.Delete(entity);

            return new OkResult();
        }
    }
}
