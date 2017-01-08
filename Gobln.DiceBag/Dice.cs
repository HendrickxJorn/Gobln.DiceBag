using System;
using System.Linq;

namespace Gobln.DiceBag
{
    /// <summary>
    /// Represents a dice type.
    /// </summary>
    public class Dice : IEquatable<Dice>
    {
        private readonly int _size;
        private readonly int _amount;
        private int _modifier;

        #region Constructors

        /// <summary>
        /// Creates an Dice object
        /// </summary>
        /// <param name="size">Dice size</param>
        public Dice(DiceTypes size)
            : this(size, 1, 0)
        {
        }

        /// <summary>
        /// Creates an Dice object
        /// </summary>
        /// <param name="size">Dice size</param>
        /// <param name="amount">Amount of dice</param>
        public Dice(DiceTypes size, int amount)
            : this(size, amount, 0)
        {
        }

        /// <summary>
        /// Creates an Dice object
        /// </summary>
        /// <param name="size">Dice size</param>
        /// <param name="amount">Amount of dice</param>
        /// <param name="modifier">Dice modifier</param>
        public Dice(DiceTypes size, int amount, int modifier)
            : this((int)size, amount, modifier)
        {
        }

        /// <summary>
        /// Creates an Dice object
        /// </summary>
        /// <param name="size">Dice size</param>
        public Dice(int size)
            : this(size, 1, 0)
        {
        }

        /// <summary>
        /// Creates an Dice object
        /// </summary>
        /// <param name="size">Dice size</param>
        /// <param name="amount">Amount of dice</param>
        public Dice(int size, int amount)
            : this(size, amount, 0)
        {
        }

        /// <summary>
        /// Creates an Dice object
        /// </summary>
        /// <param name="size">Dice size</param>
        /// <param name="amount">Amount of dice</param>
        /// <param name="modifier">Dice modifier</param>
        public Dice(int size, int amount, int modifier)
        {
            if (size < 2)
                throw new ArgumentException("Size must be greater then 1", "size");

            if (amount < 1)
                throw new ArgumentException("Amount must be greater then 0", "amount");

            ResultRoll = 0;
            _size = size;
            _amount = amount;
            _modifier = modifier;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Minimum value of the dice
        /// </summary>
        public int Min { get { return _amount + _modifier; } }

        /// <summary>
        /// Maximum value of the dice
        /// </summary>
        public int Max { get { return _amount * _size + _modifier; } }

        /// <summary>
        /// Avarage value of the dice
        /// </summary>
        public decimal Avarage { get { return ((decimal)Max + _amount) / 2 + _modifier; } }

        /// <summary>
        /// Result of the Roll, without modification
        /// </summary>
        public int ResultRoll { get; private set; }

        /// <summary>
        /// Result of the Roll, with modification
        /// </summary>
        public int Result { get { return ResultRoll == 0 ? 0 : ResultRoll + _modifier; } }

        #endregion Properties

        #region Functions

        /// <summary>
        /// Roll the dice
        /// </summary>
        /// <returns></returns>
        public int Roll()
        {
            return Roll(new RngCryptoRandom());
        }

        /// <summary>
        /// Roll the dice
        /// </summary>
        /// <param name="rcr"></param>
        /// <returns></returns>
        internal int Roll(RngCryptoRandom rcr)
        {
            ResultRoll = Enumerable.Range(1, _amount).Sum(c => rcr.Next(1, _size + 1));

            return ResultRoll + _modifier;
        }

        /// <summary>
        /// Set the modifier
        /// </summary>
        /// <param name="modifier">The value that will be added to the roll</param>
        public void SetModifier(int modifier)
        {
            _modifier = modifier;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A integer signed hash code.</returns>
        public override int GetHashCode()
        {
            return new { _size, _amount, _modifier }.GetHashCode();
        }

        #endregion Functions

        #region IEquatable<Dice>

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Dice other)
        {
            return other != null && (_amount == other._amount
                                     && _size == other._size
                                     && _modifier == other._modifier);
        }

        #endregion IEquatable<Dice>

        #region Operators

        /// <summary>
        ///
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static bool operator ==(Dice d1, Dice d2)
        {
            return ReferenceEquals(d1, null)
                ? ReferenceEquals(d2, null)
                : d1.Equals(d2);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static bool operator !=(Dice d1, Dice d2)
        {
            return !(d1 == d2);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var d = (Dice)obj;
            return Equals(d);
        }

        #endregion Operators
    }
}