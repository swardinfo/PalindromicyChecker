using System;

namespace PalindromicyChecker
{
    /// <summary>
    /// A set of maths functions to check each matrix and its sequence sets
    /// </summary>
    public static class MathFunctions
    {
        /// <summary>
        /// Converts a long the equivalent 0 left padded sequence of characters
        /// </summary>
        /// <param name="value">The long to be converted</param>
        /// <param name="radix">The base of the number to be converted</param>
        /// <param name="n">The number of characters of the sequence</param>
        /// <returns></returns>
        public static byte[] ConvertLongToSequence(long value, long radix, long n)
        {
            byte[] result = new byte[n];
            do
            {
                result[--n] = (byte)(value % radix);
                value = (value - result[n]) / radix;
            }
            while (value > 0);
            return result;
        }

        /// <summary>
        /// Converts a sequence of left 0 padded characters to an equivalent long
        /// </summary>
        /// <param name="sequence">The sequence to be converted</param>
        /// <param name="radix">The base of the number to convert the sequence to</param>
        /// <returns></returns>
        public static long ConvertSequenceToLong(byte[] sequence, long radix)
        {
            long result = 0;
            for (long i = 0, j = sequence.Length - 1; i < sequence.Length; i++, j--)
            {
                if (sequence[i] != 0)
                    result += sequence[i] * (long)Math.Pow(radix, j);
            }
            return result;
        }

        /// <summary>
        /// Returns the maximum number for a zero based matrix of base b ^ n
        /// </summary>
        /// <param name="radix">The base of the matrix</param>
        /// <param name="n">The n value of the matrix</param>
        /// <returns></returns>
        public static long GetMaxMatrixNumber(long radix, long n)
        {
            return (long)(Math.Pow(radix, n) - 1);
        }

        public static long GetMaxPermutationNumber(long radix)
        {
            long result = 0;
            for (long i = 1; i < radix; i++)
            {
                result += i * (long)(Math.Pow(radix, i));
            }
            return result;
        }

        /// <summary>
        /// Returns the factorial of the given number
        /// </summary>
        /// <param name="value">The number of which to obtain its factorial</param>
        /// <returns></returns>
        public static long Factorial(long value)
        {
            if (value == 0)
                return 1;
            return value * Factorial(value - 1);
        }
    }
}
