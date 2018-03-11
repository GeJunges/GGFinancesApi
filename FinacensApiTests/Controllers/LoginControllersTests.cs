using FinancesApi.Controllers;
using NUnit.Framework;

namespace FinancesApiTests.Controllers {
    public class LoginControllerTests {
        public LoginController _controller;

        [SetUp]
        public void SetUp() {
            _controller = new LoginController();
        }

        [Test]
        public void ShouldBeEqual() {

            Assert.AreEqual(1, 1);
        }
    }
}