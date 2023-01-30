using SnakesAndLadders.Entities;

namespace UnitTesting.Tests
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

        [Fact]
        public void GivenTheTokenIsOnSquareOne_WhenTheTokenIsMovedThreeSpaces_ThenTheTokenIsOnSquareFour()
        {
            // Arrange
            Player sut = new Player("Test");

            // Act
            sut.MoveToken(3);

            // Assert
            sut.TokenPosition.Should().Be(4);
        }

        [Fact]
        public void GivenTheTokenIsOnSquareOne_WhenTheTokenIsMovedThreeSpacesAndThenItIsMovedFourSpaces_ThenTheTokenIsOnSquareEight()
        {
            // Arrange
            Player sut = new Player("Test");

            // Act
            sut.MoveToken(3);
            sut.MoveToken(4);

            // Assert
            sut.TokenPosition.Should().Be(8);
        }
    }
}
