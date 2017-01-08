using System.Collections.Generic;
using System.Linq;

namespace Gobln.DiceBag
{
    /// <summary>
    /// Represents a container for muliple dice type.
    /// </summary>
    public class DicesCup : ICollection<Dice>
    {
        private int _modifier;

        #region Constructors

        /// <summary>
        /// Creates an DicesCup object
        /// </summary>
        public DicesCup()
        {
            Dices = new List<Dice>();
            _modifier = 0;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// List of Dices in the DicesCup
        /// </summary>
        protected List<Dice> Dices { get; set; }

        /// <summary>
        /// Result of the Roll, without modification
        /// </summary>
        public int ResultRoll { get; private set; }

        /// <summary>
        /// Result of the Roll, with modification
        /// </summary>
        public int Result { get { return ResultRoll + (ResultRoll == 0 ? 0 : _modifier); } }

        /// <summary>
        /// Avarage value of the DiceCup
        /// </summary>
        public decimal Avarage { get { return Dices.Sum(c => c.Avarage); } }

        #endregion Properties

        #region Functions

        /// <summary>
        /// Roll the dices
        /// </summary>
        /// <returns></returns>
        public int Roll()
        {
            var rcr = new RngCryptoRandom(true);

            ResultRoll = Dices.Aggregate(0, (current, c) => current += c.Roll(rcr));

            return ResultRoll;
        }

        /// <summary>
        /// Set the modifier
        /// </summary>
        /// <param name="modifier">The value that will be added to the roll</param>
        public void SetModifier(int modifier)
        {
            _modifier = modifier;
        }

        #endregion Functions

        #region ICollection

        /// <summary>
        /// Adds an object to the end of the <see cref="DicesCup"/>.
        /// </summary>
        /// <param name="item">The Dice to be added to the end of the <see cref="DicesCup"/>.</param>
        public void Add(Dice item)
        {
            Dices.Add(item);
        }

        /// <summary>
        /// Removes all elements from the <see cref="DicesCup"/>.
        /// </summary>
        public void Clear()
        {
            Dices.Clear();
        }

        /// <summary>
        /// Determines whether an element is in the <see cref="DicesCup"/>.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="DicesCup"/>.</param>
        /// <returns>True if item is found in the <see cref="DicesCup"/>; otherwise, false.</returns>
        public bool Contains(Dice item)
        {
            return Dices.Contains(item);
        }

        /// <summary>
        /// Copies the entire <see cref="DicesCup"/> to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the elements copied from <see cref="DicesCup"/>. The System.Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <exception cref="System.ArgumentNullException">Array is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">ArrayIndex is less than 0.</exception>
        /// <exception cref="System.ArgumentException">The number of elements in the source <see cref="DicesCup"/> is greater than the available space from arrayIndex to the end of the destination array.</exception>
        public void CopyTo(Dice[] array, int arrayIndex)
        {
            Dices.CopyTo(array, arrayIndex);
        }

        ///// <summary>
        ///// Returns the number of elements in a sequence.
        ///// </summary>
        ///// <returns>The number of elements in the input sequence.</returns>
        ///// <exception cref="System.ArgumentNullException">Source is null.</exception>
        ///// <exception cref="System.OverflowException">The number of elements in source is larger than System.Int32.MaxValue.</exception>
        //public override int Count(){
        //    return Dices.Count();
        //}

        /// <summary>
        /// Returns the number of elements in a sequence.
        /// </summary>
        /// <returns>The number of elements in the input sequence.</returns>
        /// <exception cref="System.ArgumentNullException">Source is null.</exception>
        /// <exception cref="System.OverflowException">The number of elements in source is larger than System.Int32.MaxValue.</exception>
        public int Count
        {
            get { return Dices.Count; }
        }

        /// <summary>
        /// Default accessor for the DicesCup.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Dice this[int index]
        {
            get
            {
                return Dices[index];
            }
            set
            {
                Dices[index] = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="DicesCup"/> is read-only.
        /// </summary>
        /// <returns>True if the <see cref="DicesCup"/> is read-only; otherwise, false.</returns>
        public bool IsReadOnly
        {
            get { return (Dices as ICollection<Dice>).IsReadOnly; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="DicesCup"/>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="DicesCup"/>.</param>
        /// <returns>True if item is successfully removed; otherwise, false. This method also returns false if item was not found in the <see cref="DicesCup"/>.</returns>
        public bool Remove(Dice item)
        {
            return Dices.Remove(item);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="DicesCup"/>.
        /// </summary>
        /// <returns> A <see cref="DicesCup"/>.Enumerator for the <see cref="DicesCup"/>.</returns>
        public IEnumerator<Dice> GetEnumerator()
        {
            return Dices.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Dices.GetEnumerator();
        }

        #endregion ICollection
    }
}