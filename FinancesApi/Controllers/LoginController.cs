using FinancesApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinancesApi.Controllers {
    [Route("api/register")]
    public class RegisterController : ControllerBase {
        private IUserRepository _repository;

        public RegisterController(IUserRepository repository) {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get() {

BadRequest();
            return new JsonResult("2");
        }
    }
}