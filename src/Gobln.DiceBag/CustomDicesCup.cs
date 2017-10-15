using System.Collections.Generic;
using System.Linq;

namespace Gobln.DiceBag
{
    /// <summary>
    /// Represents a container for muliple custom dice type.
    /// </summary>
    public class CustomDicesCup : ICollection<CustomDice>
    {
        #region Constructors

        /// <summary>
        /// Creates an DicesCup object
        /// </summary>
        public CustomDicesCup()
        {
            Dices = new List<CustomDice>();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// List of Dices in the DicesCup
        /// </summary>
        protected List<CustomDice> Dices { get; set; }

        /// <summary>
        /// Result of the Roll, with modification
        /// </summary>
        public string[] Result { get; private set; }

        #endregion Properties

        #region Functions

        /// <summary>
        /// Roll the dices
        /// </summary>
        /// <returns></returns>
        public string[] Roll()
        {
            var rcr = new RngCryptoRandom(true);

            Result = Dices.Select(c => c.Roll(rcr)).ToArray();

            return Result;
        }

        #endregion Functions

        #region ICollection

        /// <summary>
        /// Adds an object to the end of the <see cref="CustomDicesCup"/>.
        /// </summary>
        /// <param name="item">The Dice to be added to the end of the <see cref="CustomDicesCup"/>.</param>
        public void Add(CustomDice item)
        {
            Dices.Add(item);
        }

        /// <summary>
        /// Removes all elements from the <see cref="CustomDicesCup"/>.
        /// </summary>
        public void Clear()
        {
            Dices.Clear();
        }

        /// <summary>
        /// Determines whether an element is in the <see cref="CustomDicesCup"/>.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="CustomDicesCup"/>.</param>
        /// <returns>True if item is found in the <see cref="CustomDicesCup"/>; otherwise, false.</returns>
        public bool Contains(CustomDice item)
        {
            return Dices.Contains(item);
        }

        /// <summary>
        /// Copies the entire <see cref="CustomDicesCup"/> to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the elements copied from <see cref="CustomDicesCup"/>. The System.Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <exception cref="System.ArgumentNullException">Array is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">ArrayIndex is less than 0.</exception>
        /// <exception cref="System.ArgumentException">The number of elements in the source <see cref="CustomDicesCup"/> is greater than the available space from arrayIndex to the end of the destination array.</exception>
        public void CopyTo(CustomDice[] array, int arrayIndex)
        {
            Dices.CopyTo(array, arrayIndex);
        }

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
        /// Default accessor for the CustomDiceCup.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public CustomDice this[int index]
        {
            get { return Dices[index]; }
            set { Dices[index] = value; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="CustomDicesCup"/> is read-only.
        /// </summary>
        /// <returns>True if the <see cref="CustomDicesCup"/> is read-only; otherwise, false.</returns>
        public bool IsReadOnly
        {
            get { return (Dices as ICollection<CustomDice>).IsReadOnly; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="CustomDicesCup"/>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="CustomDicesCup"/>.</param>
        /// <returns>True if item is successfully removed; otherwise, false. This method also returns false if item was not found in the <see cref="CustomDicesCup"/>.</returns>
        public bool Remove(CustomDice item)
        {
            return Dices.Remove(item);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="CustomDicesCup"/>.
        /// </summary>
        /// <returns> A <see cref="CustomDicesCup"/>.Enumerator for the <see cref="CustomDicesCup"/>.</returns>
        public IEnumerator<CustomDice> GetEnumerator()
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