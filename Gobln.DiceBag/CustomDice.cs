using System;
using System.Collections.Generic;

namespace Gobln.DiceBag
{
    /// <summary>
    /// Represents a custom dice type.
    /// </summary>
    public class CustomDice : IEquatable<CustomDice>
    {
        private readonly Dictionary<int, string> _sides = new Dictionary<int, string>();

        #region Constructors

        /// <summary>
        /// Creates an CustomDice object
        /// </summary>
        /// <param name="sides">Dice sizes</param>
        public CustomDice(string[] sides)
        {
            for (var i = 0; i < sides.Length; i++)
                _sides[i] = sides[i];
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Result of the Roll
        /// </summary>
        public string Result { get; private set; }

        #endregion Properties

        #region Functions

        /// <summary>
        /// Roll the dice
        /// </summary>
        /// <returns></returns>
        public string Roll()
        {
            return Roll(new RngCryptoRandom());
        }

        /// <summary>
        /// Roll the dice
        /// </summary>
        /// <param name="rcr"></param>
        /// <returns></returns>
        internal string Roll(RngCryptoRandom rcr)
        {
            Result = _sides[rcr.Next(0, _sides.Count)];

            return Result;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A integer signed hash code.</returns>
        public override int GetHashCode()
        {
            return Result.GetHashCode();
        }

        #endregion Functions

        #region IEquatable<CustomDice>

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(CustomDice other)
        {
            return other != null && Result == other.Result;
        }

        #endregion IEquatable<CustomDice>

        #region Operators

        /// <summary>
        ///
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static bool operator ==(CustomDice d1, CustomDice d2)
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
        public static bool operator !=(CustomDice d1, CustomDice d2)
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
            var d = (CustomDice)obj;
            return Equals(d);
        }

        #endregion Operators
    }
}