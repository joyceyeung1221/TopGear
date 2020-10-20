using System;
using Xunit;
using Moq;
namespace GearBox.Tests
{
    public class ConsoleUserInputTest
    {
        public ConsoleUserInputTest()
        {

        }
        public Mock<IInputOutput> mockio = new Mock<IInputOutput>();

        [Fact]
        public void ShouldCreateGearWithRPM_WhenValidRPMRecorded()
        {
            mockio.Setup(x => x.GetUserInput()).Returns("1000");
            var ui = new ConsoleSetup(mockio.Object);
            var result = ui.CreateGear(500,1);

            Assert.IsType<Gear>(result);
            Assert.Equal(1000, result.UpperRPM);
            Assert.Equal(500, result.LowerRPM);
        }

        [Theory]
        [InlineData("", "Invalid Input, please put in a number.")]
        [InlineData("a", "Invalid Input, please put in a number.")]
        [InlineData("-1", "Upper limit needs to be larger than 1000 and less than 12000.")]
        [InlineData("999", "Upper limit needs to be larger than 1000 and less than 12000.")]
        [InlineData("12001", "Upper limit needs to be larger than 1000 and less than 12000.")]
        public void ShouldOutputErrorMessage_WhenInvalidRPMRecorded(string input, string errorMessage)
        {
            mockio.SetupSequence(x => x.GetUserInput()).Returns(input).Returns("1001");
            var ui = new ConsoleSetup(mockio.Object);
            var result = ui.CreateGear(1000,2);

            mockio.Verify(x => x.Output(errorMessage), Times.Exactly(1));

        }
    }
}
