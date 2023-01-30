using Fare;
using SnakesAndLadders.Core;
using SnakesAndLadders.Entities;
using SnakesAndLadders.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Utils.Attributes;

namespace UnitTests.Tests
{
    public class SnakesAndLaddersGameTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Theory, AutoMoqData]
        public void GivenTheTokenIsOnSquare97_WhenTheTokenIsMoved3Spaces_ThenTheTokenIsOnSquare100AndThePlayerHasWonTheGame(
            [Frozen]Mock<IDiceService> diceService)
        {
            // Arrange
            IEnumerable<Player> players = _fixture.Build<Player>()
                .CreateMany(1);

            players.ElementAt(0).MoveToken(96);

            diceService.Setup(x => x.RollDice()).Returns(3);

            var sut = new SnakesAndLaddersGame(players, diceService.Object, 100);

            // Act
            var result = sut.PlayRound();

            // Assert
            result.Player.TokenPosition.Should().Be(100);
            result.HasWonTheGame.Should().BeTrue();
        }

        [Theory, AutoMoqData]
        public void GivenTheTokenIsOnSquare97_WhenTheTokenIsMoved4Spaces_ThenTheTokenIsOnSquare97AndThePlayerHasNotWonTheGame(
            [Frozen] Mock<IDiceService> diceService)
        {
            // Arrange
            IEnumerable<Player> players = _fixture.Build<Player>()
                .CreateMany(1);

            players.ElementAt(0).MoveToken(96);

            diceService.Setup(x => x.RollDice()).Returns(4);

            var sut = new SnakesAndLaddersGame(players, diceService.Object, 100);

            // Act
            var result = sut.PlayRound();

            // Assert
            result.Player.TokenPosition.Should().Be(97);
            result.HasWonTheGame.Should().BeFalse();
        }

        [Theory, AutoMoqData]
        public void GivenAListOfTwoPlayers_WhenTheFirstRoundsEnds_ThenIsTheTurnOfThePlayerTwo(
            [Frozen] Mock<IDiceService> diceService)
        {
            // Arrange
            IEnumerable<Player> players = _fixture.Build<Player>()
                .CreateMany(2);

            var sut = new SnakesAndLaddersGame(players, diceService.Object, 100);

            // Act
            sut.PlayRound();

            // Assert
            sut.CurrentPlayerName.Should().Be(players.ElementAt(1).Name);
        }

        [Theory, AutoMoqData]
        public void GivenAListOfTwoPlayers_WhenTheSecondRoundsEnds_ThenIsTheTurnOfThePlayerOneAgain(
            [Frozen] Mock<IDiceService> diceService)
        {
            // Arrange
            IEnumerable<Player> players = _fixture.Build<Player>()
                .CreateMany(2);

            var sut = new SnakesAndLaddersGame(players, diceService.Object, 100);

            // Act
            sut.PlayRound();
            sut.PlayRound();

            // Assert
            sut.CurrentPlayerName.Should().Be(players.ElementAt(0).Name);
        }
    }
}
