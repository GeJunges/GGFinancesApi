using AutoMapper;
using FinancesApi.Entities;
using FinancesApi.Model;
using FinancesApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancesApi.Controllers {
    //[Authorize]
    [Route("api/registers")]
    public class RegistersController : Controller {
        private readonly IRegisterRepository _repository;
        private IMapper _mapper;

        public RegistersController(IRegisterRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{budget}")]
        public async Task<IActionResult> Get([FromQuery(Name = "budget")]Budget budget) {
            var entities = await _repository.Find(budget);
            var dtos = _mapper.Map<List<RegisterDto>>(entities);
            return new JsonResult(dtos);
        }
    }
}
