using SnakesAndLadders.Core;
using SnakesAndLadders.Entities;
using SnakesAndLadders.Services.Contracts;

namespace UnitTesting.Tests
{
    public class SnakesAndLaddersGameTests
    {
        [Fact]
        public void GivenTheTokenIsOnSquare97_WhenTheTokenIsMoved3Spaces_ThenTheTokenIsOnSquare100AndThePlayerHasWonTheGame()
        {
            // Arrange
            List<Player> players = new List<Player>
            {
                new Player("Test", 97)
            };
            Mock<IDiceService> diceService = new Mock<IDiceService>();
            diceService.Setup(x => x.RollDice()).Returns(3);

            var sut = new SnakesAndLaddersGame(players, diceService.Object);

            // Act
            var result = sut.PlayRound();

            // Assert
            result.Player.TokenPosition.Should().Be(100);
            result.HasWonTheGame.Should().BeTrue();
        }

        [Fact]
        public void GivenTheTokenIsOnSquare97_WhenTheTokenIsMoved4Spaces_ThenTheTokenIsOnSquare97AndThePlayerHasNotWonTheGame()
        {
            // Arrange
            List<Player> players = new List<Player>
            {
                new Player("Test", 97)
            };
            Mock<IDiceService> diceService = new Mock<IDiceService>();
            diceService.Setup(x => x.RollDice()).Returns(4);

            var sut = new SnakesAndLaddersGame(players, diceService.Object);

            // Act
            var result = sut.PlayRound();

            // Assert
            result.Player.TokenPosition.Should().Be(97);
            result.HasWonTheGame.Should().BeFalse();
        }

        [Fact]
        public void GivenThePlayerRollsAFour_WhenTheyMoveTheirToken_ThenTheTokenShouldMoveFourSpaces()
        {
            // Arrange
            List<Player> players = new List<Player>
            {
                new Player("Test")
            };
            Mock<IDiceService> diceService = new Mock<IDiceService>();
            diceService.Setup(x => x.RollDice()).Returns(4);

            var sut = new SnakesAndLaddersGame(players, diceService.Object);

            // Act
            var result = sut.PlayRound();

            // Assert
            result.Player.TokenPosition.Should().Be(5);
        }

        [Fact]
        public void GivenAListOfTwoPlayers_WhenTheFirstRoundsEnds_ThenIsTheTurnOfThePlayerTwo()
        {
            // Arrange
            List<Player> players = new List<Player>
            {
                new Player("Player 1"),
                new Player("Player 2"),
            };

            var sut = new SnakesAndLaddersGame(players, new Mock<IDiceService>().Object);

            // Act
            sut.PlayRound();

            // Assert
            sut.CurrentPlayerName.Should().Be(players.ElementAt(1).Name);
        }

        [Fact]
        public void GivenAListOfTwoPlayers_WhenTheSecondRoundsEnds_ThenIsTheTurnOfThePlayerOneAgain()
        {
            // Arrange
            List<Player> players = new List<Player>
            {
                new Player("Player 1"),
                new Player("Player 2"),
            };

            var sut = new SnakesAndLaddersGame(players, new Mock<IDiceService>().Object);

            // Act
            sut.PlayRound();
            sut.PlayRound();

            // Assert
            sut.CurrentPlayerName.Should().Be(players.ElementAt(0).Name);
        }
    }
}
