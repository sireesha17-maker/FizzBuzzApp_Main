using FizzBuzzAPI.Controllers;
using FizzBuzzAPI.Interfaces;
using FizzBuzzAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;

namespace FizzBuzzAPI.Tests.Controllers
{
    [TestFixture]
    public class FizzBuzzControllerTests
    {
        private FizzBuzzController _controller;
        private Mock<IFizzBuzzService> _fizzBuzzServiceMock;

        [SetUp]
        public void SetUp()
        {
            _fizzBuzzServiceMock = new Mock<IFizzBuzzService>();
            _controller = new FizzBuzzController(_fizzBuzzServiceMock.Object);
        }

        [Test]
        public void Post_NullOrEmptyArray_ReturnsBadRequest()
        {
            // Act
            var result = _controller.Post(null);

            // Assert
            ClassicAssert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public void Post_ValidArray_ReturnsOkResult()
        {
            // Arrange
            var input = new[] { "1", "3", "5" };
            var expectedResults = new List<FizzBuzzResult>
            {
                new FizzBuzzResult { Input = "1", Result = "1" },
                new FizzBuzzResult { Input = "3", Result = "Fizz" },
                new FizzBuzzResult { Input = "5", Result = "Buzz" }
            };
            _fizzBuzzServiceMock.Setup(s => s.ProcessValue(It.IsAny<string>()))
                                .Returns((string value) => expectedResults.Find(r => r.Input == value));

            // Act
            var result = _controller.Post(input) as OkObjectResult;
            var actualResults = result.Value as List<FizzBuzzResult>;

            // Assert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(expectedResults.Count, actualResults.Count);
            for (int i = 0; i < expectedResults.Count; i++)
            {
                ClassicAssert.AreEqual(expectedResults[i].Input, actualResults[i].Input);
                ClassicAssert.AreEqual(expectedResults[i].Result, actualResults[i].Result);
            }
        }
    }
}
