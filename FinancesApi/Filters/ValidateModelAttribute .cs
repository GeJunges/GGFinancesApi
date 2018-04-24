using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FinancesApi.Filters {
    public class ValidateModelAttribute : ActionFilterAttribute {

        public override void OnActionExecuting(ActionExecutingContext context) {
            if (!context.ModelState.IsValid) {
                var errors = context.ModelState.ToDictionary(e => e.Key, e => e.Value.Errors);

                var jsonResult = new JsonResult(new { error = errors });
                jsonResult.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                context.Result = jsonResult;
            }
        }
    }
}