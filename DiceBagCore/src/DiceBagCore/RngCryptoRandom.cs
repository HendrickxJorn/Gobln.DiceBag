using System;
using System.Security.Cryptography;

namespace Gobln.DiceBag
{
    /// <summary>
    /// Represents a cryptographic pseudo-random number generator.
    /// </summary>
    public class RngCryptoRandom : Random
    {
        private readonly RandomNumberGenerator _rng;

        private byte[] _buffer;

        private int _bufferPosition;

        private readonly bool _randomPool;

        /// <summary>
        /// Initializes a new instance of the RngCryptoRandom class.
        /// </summary>
        public RngCryptoRandom()
            : this(true)
        { }

        /// <summary>
        /// Initializes a new instance of the RngCryptoRandom class, enforcing to use an random pool.
        /// </summary>
        /// <param name="randomPool">Enforce to use an random pool or not.</param>
        public RngCryptoRandom(bool randomPool)
        {
            _rng = RandomNumberGenerator.Create();
            _randomPool = randomPool;
        }

        /// <summary>
        /// Returns a nonnegative random number.
        /// </summary>
        /// <returns>A 32-bit signed integer greater than or equal to zero and less than System.Int32.MaxValue.</returns>
        public override int Next()
        {
            return (int)GetRandomUInt32() & 0x7FFFFFFF;
        }

        /// <summary>
        /// Returns a nonnegative random number less than the specified maximum.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the random number to be generated. maxValue must be greater than or equal to zero.</param>
        /// <returns>A 32-bit signed integer greater than or equal to minValue and less than maxValue; that is, the range of return values includes minValue but not maxValue. If minValue equals maxValue, minValue is returned.</returns>
        /// <exception cref="ArgumentOutOfRangeException">MaxValue is less than zero.</exception>
        public override int Next(int maxValue)
        {
            return Next(0, maxValue);
        }

        /// <summary>
        /// Returns a random number within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns>A 32-bit signed integer greater than or equal to minValue and less than maxValue; that is, the range of return values includes minValue but not maxValue. If minValue equals maxValue, minValue is returned.</returns>
        /// <exception cref="ArgumentOutOfRangeException">MinValue is greater than maxValue.</exception>
        /// <exception cref="ArgumentOutOfRangeException">MaxValue is less than zero.</exception>
        public override int Next(int minValue, int maxValue)
        {
            if (maxValue < 0)
                throw new ArgumentOutOfRangeException("maxValue");

            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException("minValue");

            if (minValue == maxValue)
                return minValue;

            var diff = (long)maxValue - minValue;

            while (true)
            {
                var rand = GetRandomUInt32();

                var max = 1 + (long)uint.MaxValue;
                var remainder = max % diff;

                if (rand < max - remainder)
                    return (int)(minValue + rand % diff);
            }
        }

        /// <summary>
        /// Returns a random number between 0.0 and 1.0.
        /// </summary>
        /// <returns>A double-precision floating point number greater than or equal to 0.0, and less than 1.0.</returns>
        public override double NextDouble()
        {
            return GetRandomUInt32() / (1.0 + uint.MaxValue);
        }

        /// <summary>
        /// Fills the elements of a specified array of bytes with random numbers.
        /// </summary>
        /// <param name="buffer">An array of bytes to contain random numbers.</param>
        /// <exception cref="ArgumentNullException">Buffer is null.</exception>
        public override void NextBytes(byte[] buffer)
        {
            if (buffer == null)
                throw new ArgumentNullException("buffer");

            lock (this)
            {
                if (_randomPool && _buffer == null)
                    InitBuffer();

                var bLength = buffer.Length;

                //Check if we can fit the requested number of bytes in the buffer
                // else get direcly form RNGCryptoProvider
                if (_buffer != null && (_randomPool && _buffer.Length <= bLength))
                {
                    CreateRandomBuffer(bLength);

                    Buffer.BlockCopy(_buffer, _bufferPosition, buffer, 0, bLength);

                    _bufferPosition += bLength;
                }
                else
                    _rng.GetBytes(buffer);
            }
        }

        #region Private

        private void InitBuffer()
        {
            var bufferSize = _randomPool ? 1024 : 4; // Must be able to divide by 4

            if (_buffer == null || _buffer.Length != bufferSize)
                _buffer = new byte[bufferSize];

            _rng.GetBytes(_buffer);
            _bufferPosition = 0;
        }

        private uint GetRandomUInt32()
        {
            lock (this)
            {
                CreateRandomBuffer(4);

                var r = BitConverter.ToUInt32(_buffer, _bufferPosition);

                _bufferPosition += 4;

                return r;
            }
        }

        private void CreateRandomBuffer(int requiredBytes)
        {
            if (_buffer == null)
                InitBuffer();

            if (requiredBytes > _buffer.Length)
                throw new ArgumentOutOfRangeException("bufferSize", "Buffer size is to small.");

            if (_buffer.Length - _bufferPosition < requiredBytes)
                InitBuffer();
        }

        #endregion Private
    }
}