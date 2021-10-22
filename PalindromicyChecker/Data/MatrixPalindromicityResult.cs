using System.Collections.Generic;

namespace PalindromicyChecker
{
    public class MatrixPalindromicityResult
    {
        #region Constructor

        /// <summary>
        /// The default constructor for the class
        /// </summary>
        public MatrixPalindromicityResult()
        {
            SelfPalindromicSets = new Dictionary<int, long>();
            PairedPalindromicSets = new Dictionary<int, long>();
        }

        /// <summary>
        /// Creates a new MatrixPalindromicityResult initialized for a matrix of value n
        /// </summary>
        /// <param name="n">The n value of the matrix</param>
        public MatrixPalindromicityResult(long n)
        {
            SelfPalindromicSets = new Dictionary<int, long>();
            PairedPalindromicSets = new Dictionary<int, long>();
            for (int i = 1; i <= n; i++)
            {
                SelfPalindromicSets.Add(i, 0);
                PairedPalindromicSets.Add(i, 0);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Indicates the matrix was palindromic
        /// </summary>
        public bool IsMatrixPalindromic { get; set; }

        /// <summary>
        /// The number at which the matrix was proved not to be palindromic
        /// </summary>
        public long FailedNumber { get; set; }

        /// <summary>
        /// The set type in which the number at which the matrix was proved not to be palindromic occurred
        /// </summary>
        public SetType FailedSetType { get; set; }

        /// <summary>
        /// The number of self palindromic sets and the number of pairs in each set
        /// </summary>
        public Dictionary<int, long> SelfPalindromicSets { get; set; }

        /// <summary>
        /// The number of paired palindromic sets and the number of pairs in each set
        /// </summary>
        public Dictionary<int, long> PairedPalindromicSets { get; set; }

        #endregion
    }
}
