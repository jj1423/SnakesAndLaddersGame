using SnakesAndLadders.Services;

namespace UnitTesting.Tests
{
    public class SixFacesDiceServiceTests
    {
        [Fact]
        public void GivenADiceWithSixFaces_WhenTheDiceIsRolled_ThenTheResultShouldBeBetweenOneAndSix()
        {
            // Arrange
            List<int> scores = new List<int>();
            SixFacesDiceService sut = new SixFacesDiceService();

            // Act
            for (int i = 0; i < 100; i++)
            {
                scores.Add(sut.RollDice());
            }

            // Assert
            scores.Where(x => x < 1 || x > 6).Should().BeEmpty();
        }
    }
}
