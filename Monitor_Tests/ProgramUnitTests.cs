using System;
using Xunit;
using Observing;

namespace Monitor_Tests
{
    public class ProgramUnitTests
    { 
        [Theory]
        [InlineData("abc", "0.5", "1")]
        [InlineData("abc", "1", "0.5")]
        [InlineData("abc", "-5", "1")]
        [InlineData("abc", "5", "-1")]
        [InlineData("", "5", "1")]
        [InlineData(null, "5", "1")]
        public void Init_GivenWrongFormat_ThrowsException(string name, string lifetime, string frequency)
        {
            // Arrange
            string[] arguments = new string[] { name, lifetime, frequency };
            Program p = new();
            // Act   &   Assert
            Assert.Throws<ArgumentException>(() => p.Init(arguments));
        }
    }
}

