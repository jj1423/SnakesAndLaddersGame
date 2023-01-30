using SnakesAndLadders.Services.Contracts;
using System;

namespace SnakesAndLadders.Services
{
    /// <summary>
    /// Implementation for a six faces dice service
    /// </summary>
    public class SixFacesDiceService : IDiceService
    {
        private readonly Random _random;
        private readonly int _maxValue;

        /// <summary>
        /// Creates a new instance of <see cref="SixFacesDiceService"/>
        /// </summary>
        public SixFacesDiceService()
        {
            _random = new Random();
            _maxValue = 7; // +1 because the max value is excluded
        }

        /// <inheritdoc/>
        public int RollDice()
        {
            return _random.Next(1, _maxValue);
        }
    }
}
