
using System;
using System.Threading.Tasks;
using AutoMapper;
using FinancesApi.Entities;
using FinancesApi.Models;
using FinancesApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancesApi.Controllers {

    //[Authorize]
    [Route("api/registers")]
    [Produces("application/json")]
    public class RegistersController : ControllerBase {
        private readonly IPersistenceRepository<User> _persistenceRepository;
        private readonly ISearchRepository<User> _searchRepository;

        private readonly IMapper _autoMapper;


        public RegistersController(IPersistenceRepository<User> persistenceRepository,
                                   ISearchRepository<User> searchRepository,
                                   IMapper autoMapper) {
            _persistenceRepository = persistenceRepository;
            _searchRepository = searchRepository;
            _autoMapper = autoMapper;
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery(Name = "filter")] Filter filter) {
            var users = await _searchRepository.FindAll(filter);
            return new JsonResult(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) {
            var user = await _searchRepository.FindById(id);

            if (user == null) {
                return new JsonResult(new NotFoundResult());
            }

            return new JsonResult(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserDto userDto) {
            var user = _autoMapper.Map<User>(userDto);
            await _persistenceRepository.Insert(user);

            return new JsonResult(userDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid id, [FromBody]UserDto userDto) {
            var user = await _searchRepository.FindById(id);

            if (user == null) {
                return new JsonResult(new NotFoundResult());
            }

            var userToUpdate = _autoMapper.Map(userDto, user);
            await _persistenceRepository.Update(userToUpdate);

            return new JsonResult(userToUpdate);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id) {
            var user = await _searchRepository.FindById(id);

            if (user == null) {
                return new JsonResult(new NotFoundResult());
            }

            await _persistenceRepository.Delete(user);

            return new JsonResult(new OkResult());
        }
    }
}