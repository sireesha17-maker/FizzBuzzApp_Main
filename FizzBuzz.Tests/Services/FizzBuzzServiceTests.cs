using FizzBuzzAPI.Interfaces;
using FizzBuzzAPI.Models;
using FizzBuzzAPI.Services;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace FizzBuzzAPI.Tests.Services
{
    [TestFixture]
    public class FizzBuzzServiceTests
    {
        private FizzBuzzService _fizzBuzzService;
        private Mock<IDivisionService> _divisionByThreeServiceMock;
        private Mock<IDivisionService> _divisionByFiveServiceMock;

        [SetUp]
        public void SetUp()
        {
            _divisionByThreeServiceMock = new Mock<IDivisionService>();
            _divisionByFiveServiceMock = new Mock<IDivisionService>();
            _fizzBuzzService = new FizzBuzzService(_divisionByThreeServiceMock.Object, _divisionByFiveServiceMock.Object);
        }

        [Test]
        public void ProcessValue_InputDivisibleByThreeAndFive_ReturnsFizzBuzz()
        {
            // Arrange
            var input = "15";
            _divisionByThreeServiceMock.Setup(s => s.IsDivisible(It.IsAny<int>())).Returns(true);
            _divisionByFiveServiceMock.Setup(s => s.IsDivisible(It.IsAny<int>())).Returns(true);

            // Act
            var result = _fizzBuzzService.ProcessValue(input);

            // Assert
            ClassicAssert.AreEqual("FizzBuzz", result.Result);
        }

        [Test]
        public void ProcessValue_InputDivisibleByThree_ReturnsFizz()
        {
            // Arrange
            var input = "9";
            _divisionByThreeServiceMock.Setup(s => s.IsDivisible(It.IsAny<int>())).Returns(true);
            _divisionByFiveServiceMock.Setup(s => s.IsDivisible(It.IsAny<int>())).Returns(false);

            // Act
            var result = _fizzBuzzService.ProcessValue(input);

            // Assert
            ClassicAssert.AreEqual("Fizz", result.Result);
        }

        [Test]
        public void ProcessValue_InputDivisibleByFive_ReturnsBuzz()
        {
            // Arrange
            var input = "10";
            _divisionByThreeServiceMock.Setup(s => s.IsDivisible(It.IsAny<int>())).Returns(false);
            _divisionByFiveServiceMock.Setup(s => s.IsDivisible(It.IsAny<int>())).Returns(true);

            // Act
            var result = _fizzBuzzService.ProcessValue(input);

            // Assert
            ClassicAssert.AreEqual("Buzz", result.Result);
        }

        [Test]
        public void ProcessValue_InputNotDivisibleByThreeOrFive_ReturnsDivisions()
        {
            // Arrange
            var input = "7";
            _divisionByThreeServiceMock.Setup(s => s.IsDivisible(It.IsAny<int>())).Returns(false);
            _divisionByFiveServiceMock.Setup(s => s.IsDivisible(It.IsAny<int>())).Returns(false);
            _divisionByThreeServiceMock.Setup(s => s.DivisionMessage(It.IsAny<int>())).Returns("Divided 7 by 3");
            _divisionByFiveServiceMock.Setup(s => s.DivisionMessage(It.IsAny<int>())).Returns("Divided 7 by 5");

            // Act
            var result = _fizzBuzzService.ProcessValue(input);

            // Assert
            ClassicAssert.IsTrue(result.Divisions.Contains("Divided 7 by 3"));
            ClassicAssert.IsTrue(result.Divisions.Contains("Divided 7 by 5"));
        }

        [Test]
        public void ProcessValue_InvalidInput_ReturnsInvalidItem()
        {
            // Arrange
            var input = "invalid";

            // Act
            var result = _fizzBuzzService.ProcessValue(input);

            // Assert
            ClassicAssert.AreEqual("Invalid item", result.Result);
        }
    }
}
