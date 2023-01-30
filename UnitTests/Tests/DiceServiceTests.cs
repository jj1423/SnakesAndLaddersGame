using SnakesAndLadders.Services;

namespace UnitTests.Tests
{
    public class DiceServiceTests
    {
        [Fact]
        public void WhenRollsADice_ReturnsAScore_ShouldBeBetweenOneAndSix()
        {
            // Arrange
            List<int> scores = new List<int>();
            SixFacesDiceService sut = new SixFacesDiceService(6);

            // Act
            for (int i = 0; i < 10; i++)
            {
                scores.Add(sut.RollDice());
            }
            
            // Assert
            scores.Where(x => x < 1 || x > 6).Should().BeEmpty();
        }
    }
}
