using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FinancesApi.Filters {
    public class ValidateModelAttribute : ActionFilterAttribute {

        public override void OnActionExecuting(ActionExecutingContext context) {
            // if (!context.ModelState.IsValid) {
            //     context.Result = new BadRequestObjectResult(context.ModelState);
            // }
        }
    }
}