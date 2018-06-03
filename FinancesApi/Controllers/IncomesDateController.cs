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
    [Route("api/incomes")]
    public class IncomesDateController : Controller {
        private readonly IIncomesDateRepository _repository;
        private IMapper _mapper;

        public IncomesDateController(IIncomesDateRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery(Name ="date")]DateTime date) {

            var entities = await _repository.FindByDate(date);

            var entriesDateDto = _mapper.Map<List<IncomeDateDto>>(entities);

            return new JsonResult(entriesDateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IncomeDateDto entryDateDto) {

            var entity = _mapper.Map<IncomeDate>(entryDateDto);
            await _repository.Add(entity);

            var dto = _mapper.Map<IncomeDateDto>(entity);
            return new JsonResult(dto);
        }
    }
}
