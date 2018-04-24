using FinancesApi.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;

namespace FinancesApiTests.Filters {
    public class ValidateModelAttributeTests {

        private HttpContext _httpContext;
        private ActionExecutingContext _actionContextMock;
        private ValidateModelAttribute _validateModelAttribute;
        
        [SetUp]
        public void SetUp() {
            _httpContext = new DefaultHttpContext();
            _actionContextMock = new ActionExecutingContext(
            new ActionContext
            {
                HttpContext = _httpContext,
                RouteData = new RouteData(),
                ActionDescriptor = new ActionDescriptor(),
            },
            new List<IFilterMetadata>(),
            new Dictionary<string, object>(),
            new Mock<Controller>().Object);

            _validateModelAttribute = new ValidateModelAttribute();
        }

        [Test]
        public void ShouldNotReturnBadRequestObjectResultIfModelStateIsValid() {
            _validateModelAttribute.OnActionExecuting(_actionContextMock);

            Assert.IsNull(_actionContextMock.Result);
        }

        [Test]
        public void ShouldReturnBadRequestObjectResultIfModelStateIsNotValid() {
            _actionContextMock.ModelState.AddModelError("error", "error");

            _validateModelAttribute.OnActionExecuting(_actionContextMock);
            
            var actual = ((JsonResult)_actionContextMock.Result);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, actual.StatusCode);
        }
    }
}