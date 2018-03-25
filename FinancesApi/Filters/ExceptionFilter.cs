
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FinancesApi.Filters {
    public class ExceptionFilter : ExceptionFilterAttribute {

        public override void OnException(ExceptionContext context) {
            if (context.Exception != null) {
                var jsonResult = new JsonResult(new { error = context.Exception.Message });
                jsonResult.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                context.Result = jsonResult;
            }
        }
    }

}
