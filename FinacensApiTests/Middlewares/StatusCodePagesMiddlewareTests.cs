using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FinancesApi.Logger;
using FinancesApi.Middlewares;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;

namespace FinancesApiTests.Middlewares {

    public class StatusCodePagesMiddlewareTests {
        private Mock<HttpContext> _httpContextMock;
        private Mock<HttpRequest> _requestMock;
        private Mock<HttpResponse> _responseMock;
        private Mock<ILoggerWrapper> _loggerMock;

        private RequestDelegate _next;
        private StatusCodePagesMiddleware _middleware;
        private int _onNextCalledTimes;
        private readonly Task _onNextResult = Task.FromResult(0);

        [SetUp]
        public void SetUp() {
            _loggerMock = new Mock<ILoggerWrapper>();
            _httpContextMock = new Mock<HttpContext>();
            _next = _ => {
                Interlocked.Increment(ref _onNextCalledTimes);
                return _onNextResult;
            };

            _responseMock = new Mock<HttpResponse>();
            _responseMock.SetupGet(mock => mock.StatusCode).Returns(StatusCodes.Status200OK);
            _responseMock.SetupGet(mock => mock.Body).Returns(new MemoryStream());


            var path = new PathString("/api");
            _requestMock = new Mock<HttpRequest>();
            _requestMock.SetupGet(mock => mock.Path).Returns(path);

            _httpContextMock.SetupGet(mock => mock.Request).Returns(_requestMock.Object);
            _httpContextMock.SetupGet(mock => mock.Response).Returns(_responseMock.Object);

            _middleware = new StatusCodePagesMiddleware(_next, _loggerMock.Object);
        }

        [Test]
        public void Invoke_should_log_info() {
            var expected = "Error: 404 happend";
            _responseMock.SetupGet(mock => mock.StatusCode).Returns(StatusCodes.Status404NotFound);
            _httpContextMock.SetupGet(mock => mock.Response).Returns(_responseMock.Object);

            _middleware.Invoke(_httpContextMock.Object).ConfigureAwait(true);

            _loggerMock.Verify(mock => mock.Info(It.IsAny<string>()), Times.Once);
            _loggerMock.Verify(mock => mock.Info(expected));
        }

        [Test]
        public void Invoke_should_log_error_if_some_exception_happend() {
            var expected = new Exception("Error");
            _httpContextMock.SetupGet(mock => mock.Request).Throws(expected);

            _middleware.Invoke(_httpContextMock.Object).ConfigureAwait(true);

            _loggerMock.Verify(mock => mock.Error(It.IsAny<string>()), Times.Once);
            _loggerMock.Verify(mock => mock.Error($"Error: {expected.Message}"));
        }

        [Test]
        public void Invoke_should_not_return_message_on_response_if_path_dont_have_api_word() {
            _responseMock = new Mock<HttpResponse>();
            _responseMock.SetupGet(mock => mock.StatusCode).Returns(StatusCodes.Status404NotFound);

            var path = new PathString("/test");
            _requestMock = new Mock<HttpRequest>();
            _requestMock.SetupGet(mock => mock.Path).Returns(path);

            _httpContextMock.SetupGet(mock => mock.Request).Returns(_requestMock.Object);
            _httpContextMock.SetupGet(mock => mock.Response).Returns(_responseMock.Object);

            _middleware.Invoke(_httpContextMock.Object).ConfigureAwait(true);

            _responseMock.VerifySet(m => m.StatusCode = StatusCodes.Status404NotFound, Times.Never());
            _responseMock.VerifySet(m => m.WriteAsync(It.IsAny<string>()), Times.Never());
        }

        [Test]
        public void Invoke_should_not_return_message_on_response_if_status_code_200Ok() {
            _middleware.Invoke(_httpContextMock.Object).ConfigureAwait(true);

            _responseMock.VerifySet(m => m.StatusCode = StatusCodes.Status200OK, Times.Never());
            _responseMock.VerifySet(m => m.WriteAsync(It.IsAny<string>()), Times.Never());
        }

        [Test]
        public void Invoke_should_return_message_on_response_if_stauts_code_404NotFound() {
            _responseMock.SetupGet(mock => mock.StatusCode).Returns(StatusCodes.Status404NotFound);
            _httpContextMock.SetupGet(mock => mock.Response).Returns(_responseMock.Object);

            _middleware.Invoke(_httpContextMock.Object).ConfigureAwait(true);

            _responseMock.VerifySet(m => m.StatusCode = StatusCodes.Status404NotFound, Times.Once);
            _responseMock.VerifySet(m => m.WriteAsync(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Invoke_should_return_message_on_response_if_stauts_code_Status401Unauthorized() {
            _responseMock.SetupGet(mock => mock.StatusCode).Returns(StatusCodes.Status401Unauthorized);
            _httpContextMock.SetupGet(mock => mock.Response).Returns(_responseMock.Object);

            _middleware.Invoke(_httpContextMock.Object).ConfigureAwait(true);

            _responseMock.VerifySet(m => m.StatusCode = StatusCodes.Status401Unauthorized, Times.Once);
            _responseMock.VerifySet(m => m.WriteAsync(It.IsAny<string>()), Times.Once);
        }
    }
}