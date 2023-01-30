namespace SnakesAndLadders.Entities
{
    /// <summary>
    /// Class which represents a game player
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Player name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Player token position
        /// </summary>
        public int TokenPosition { get; private set; }

        /// <summary>
        /// Creates a new instance of <see cref="Player"/>
        /// </summary>
        /// <param name="name">Player name</param>
        public Player(string name)
        {
            Name = name;
            TokenPosition = 1;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Player"/>
        /// </summary>
        /// <param name="name">Player name</param>
        /// <param name="initialTokenPosition">Initial token position</param>
        public Player(string name, int initialTokenPosition)
        {
            Name = name;
            TokenPosition = initialTokenPosition;
        }

        /// <summary>
        /// Moves the player token
        /// </summary>
        /// <param name="numberOfPositions">Number of positions to move</param>
        /// <returns></returns>
        public int MoveToken(int numberOfPositions)
        {
            return TokenPosition += numberOfPositions;
        }
    }
}
