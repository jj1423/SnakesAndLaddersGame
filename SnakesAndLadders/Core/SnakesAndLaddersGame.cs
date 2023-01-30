using SnakesAndLadders.Entities;
using SnakesAndLadders.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SnakesAndLadders.Core
{
    /// <summary>
    /// The game of the snakes and ladders
    /// </summary>
    public class SnakesAndLaddersGame
    {
        private readonly IEnumerable<Player> _players;
        private readonly IDiceService _diceService;
        private readonly int _boardSize = 100;
        private int _currentPlayerIndex = 0;

        /// <summary>
        /// Player name of the current round
        /// </summary>
        public string CurrentPlayerName => _players.ElementAt(_currentPlayerIndex).Name;

        /// <summary>
        /// Player token position of the current round
        /// </summary>
        public int CurrentPlayerTokenPosition => _players.ElementAt(_currentPlayerIndex).TokenPosition;

        /// <summary>
        /// Creates a new instance of <see cref="SnakesAndLaddersGame"/> and starts a new game
        /// </summary>
        /// <param name="players">Collection with the players</param>
        /// <param name="diceService">Dice service</param>
        public SnakesAndLaddersGame(IEnumerable<Player> players, IDiceService diceService)
        {
            _players = players;
            _diceService = diceService;
        }

        /// <summary>
        /// Rolls the dice and updates the player token position; it also determines if the game has been won
        /// </summary>
        /// <returns>The round info</returns>
        public RoundResult PlayRound()
        {
            RoundResult result = new RoundResult();
            result.RollDiceScore = _diceService.RollDice();
            result.Player = _players.ElementAt(_currentPlayerIndex);

            // Only updates the player current position if it does not overcome the board size
            if (result.Player.TokenPosition + result.RollDiceScore <= _boardSize)
            {
                result.Player.MoveToken(result.RollDiceScore);
                result.HasWonTheGame = result.Player.TokenPosition == _boardSize;
            }

            // Updates the next player index and resets it if is necessary
            if (++_currentPlayerIndex >= _players.Count())
            {
                _currentPlayerIndex = 0;
            }

            return result;
        }
    }
}
