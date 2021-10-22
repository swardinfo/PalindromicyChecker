namespace PalindromicyChecker
{
    /// <summary>
    /// An item to store in a Combobox
    /// </summary>
    internal class Item
    {
        #region Constructor

        /// <summary>
        /// A constructor to create a new item with a set value
        /// </summary>
        /// <param name="value">The value of the item</param>
        public Item(long value)
        {
            Value = value;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The name of the item
        /// </summary>
        public string Name { get { return Value.ToString(); } }

        /// <summary>
        /// The value of the item
        /// </summary>
        public long Value { get; private set; }

        #endregion
    }
}
