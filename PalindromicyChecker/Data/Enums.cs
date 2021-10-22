namespace PalindromicyChecker
{
    /// <summary>
    /// Specifies the type of palindromic set of sequences
    /// </summary>
    internal enum SetType
    {
        /// <summary>
        /// Default of none when initializing the type
        /// </summary>
        None,

        /// <summary>
        /// Specifies all the sequences in the set are paired to another within the same set
        /// </summary>
        SelfPaindromic,

        /// <summary>
        /// Specifies all the sequences in the set are paired to another set
        /// </summary>
        PairedPalindromic
    }
}
