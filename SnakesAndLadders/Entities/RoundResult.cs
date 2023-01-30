namespace SnakesAndLadders.Entities
{
    /// <summary>
    /// Class which represents a round game info result
    /// </summary>
    public class RoundResult
    {
        /// <summary>
        /// Player who has played the round
        /// </summary>
        public Player Player { get; set; }
        
        /// <summary>
        /// Roll dice score
        /// </summary>
        public int RollDiceScore { get; set; }

        /// <summary>
        /// If true, the game is over because the player has won in this round
        /// </summary>
        public bool HasWonTheGame { get; set; }
    }
}
