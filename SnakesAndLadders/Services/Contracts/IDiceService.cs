namespace SnakesAndLadders.Services.Contracts
{
    /// <summary>
    /// Contract for a dice service
    /// </summary>
    public interface IDiceService
    {
        /// <summary>
        /// Rolls a dice
        /// </summary>
        /// <returns>The score obtained by the dice</returns>
        int RollDice();
    }
}
