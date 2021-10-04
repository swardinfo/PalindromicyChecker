namespace PalindromicyChecker
{
    /// <summary>
    /// A matrix number and its equivalent number sequence
    /// </summary>
    public class NumberSequence
    {
        #region Constructor

        /// <summary>
        /// Creates a new NumberSequence initialized with a number and a sequence
        /// </summary>
        /// <param name="number"></param>
        /// <param name="sequence"></param>
        public NumberSequence(long number, byte[] sequence)
        {
            Number = number;
            Sequence = sequence;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The number of this number sequence
        /// </summary>
        public long Number { get; set; }

        /// <summary>
        /// The equivalent 0 left padded sequence of characters for this number
        /// </summary>
        public byte[] Sequence { get; set; }

        #endregion
    }
}
