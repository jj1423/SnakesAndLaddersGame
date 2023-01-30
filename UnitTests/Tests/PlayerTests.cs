using SnakesAndLadders.Entities;

namespace UnitTests.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void GivenTheGameIsStarted_WhenTheTokenIsPlacedOnTheBoard_ThenTheTokenIsOnSquareOne()
        {
            // Arrange
            Player sut = new Player("Test");

            // Act
            // Assert
            sut.TokenPosition.Should().Be(1);
        }

        [Theory, AutoMoqData]
        public void GivenTheTokenIsOnSquareOne_WhenTheTokenIsMovedThreeSpaces_ThenTheTokenIsOnSquareFour(
            Player sut)
        {
            // Arrange
            // Act
            sut.MoveToken(3);

            // Assert
            sut.TokenPosition.Should().Be(4);
        }

        [Theory, AutoMoqData]
        public void GivenTheTokenIsOnSquareOne_WhenTheTokenIsMovedThreeSpacesAndThenItIsMovedFourSpaces_ThenTheTokenIsOnSquareEight(
            Player sut)
        {
            // Arrange
            // Act
            sut.MoveToken(3);
            sut.MoveToken(4);

            // Assert
            sut.TokenPosition.Should().Be(8);
        }
    }
}
