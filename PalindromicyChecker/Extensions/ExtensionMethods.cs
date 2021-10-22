using System;

namespace PalindromicyChecker
{
    /// <summary>
    /// Miscellaneous set of extension methods
    /// </summary>
    internal static class ExtensionMethods
    {
        /// <summary>
        /// Extension to the array class, rotates the elements in an array a specified number to the left
        /// </summary>
        /// <typeparam name="T">The type of elements within the array</typeparam>
        /// <param name="array">The array to be rotated</param>
        /// <param name="shift">The number of positions to rotate</param>
        /// <returns></returns>
        public static T[] RotateLeft<T>(this T[] array, long shift)
        {
            if (shift >= array.Length)
                throw new ArgumentOutOfRangeException("shift", "The shift length must be less than the length of the array");
            var result = new T[array.Length];
            Array.Copy(array, shift, result, 0, array.Length - shift);
            Array.Copy(array, 0, result, array.Length - shift, shift);
            return result;
        }

        /// <summary>
        /// Extension to the array class, rotates the elements in an array a specified number to the right
        /// </summary>
        /// <typeparam name="T">The type of elements within the array</typeparam>
        /// <param name="array">The array to be rotated</param>
        /// <param name="shift">The number of positions to rotate</param>
        /// <returns></returns>
        public static T[] RotateRight<T>(this T[] array, long shift)
        {
            if (shift >= array.Length)
                throw new ArgumentOutOfRangeException("shift", "The shift length must be less than the length of the array");
            var result = new T[array.Length];
            Array.Copy(array, array.Length - shift, result, 0, shift);
            Array.Copy(array, 0, result, shift, array.Length - shift);
            return result;
        }
    }
}
