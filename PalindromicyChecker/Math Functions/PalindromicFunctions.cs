using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PalindromicyChecker
{
    /// <summary>
    /// A set of functions to test if a matrix consists only of paired palindromic sequences and/or self palindromic pairs
    /// </summary>
    internal class PalindromicFunctions
    {
        #region Methods

        /// <summary>
        /// Checks if a matrix of the supplied values consists only of paired palindromic sequences and/or self palindromic pairs
        /// </summary>
        /// <param name="radix">The base of the matrix to check</param>
        /// <param name="n">The n value of the matrix to check</param>
        /// <param name="token">A CancellationToken to enable the user to cancel the operation</param>
        /// <param name="progress">The progress of the operation to be reported back to the UI</param>
        /// <param name="chunkSize">The number of sequences to be tested in each thread</param>
        /// <param name="permutationsOnly">Sets whether only the sets of permutations are to be checked</param>
        /// <param name="maxProcessors">The number of processor cores to be used for processing</param>
        /// <returns></returns>
        public MatrixPalindromicityResult IsMatrixPalindromicAsync(long radix, long n, CancellationToken token, IProgress<ProgressReportModel> progress, long chunkSize, bool permutationsOnly, int maxProcessors)
        {
            var result = new MatrixPalindromicityResult(n) { IsMatrixPalindromic = true };
            long maxSetNumber = MathFunctions.GetMaxMatrixNumber(radix, n);
            // Only check to the mean of the matrix
            long maxCheck = (long)Math.Ceiling((double)maxSetNumber / 2);
            // Set the number of rotations for each sequence here once so that it doesn't get recalculated with each chunk
            var rotations = n - 1;
            // Process the remainder part of the matrix first before processing chunks
            var offset = maxCheck % chunkSize;
            result.FailedNumber = -1;
            if (offset != 0)
            {
                result = CheckSets(0, offset, radix, n, maxSetNumber, rotations, permutationsOnly);
                if (!result.IsMatrixPalindromic)
                    return result;
            }
            // If the loop size is zero then the mean of the matrix was less than the chunk size and there will be no more to process but we still report the progress
            var loopSize = (maxCheck - offset) / chunkSize;
            var numbersProcessed = offset;
            var report = new ProgressReportModel
            {
                PercentageCompleted = numbersProcessed < long.MaxValue / 100 ? (int)(numbersProcessed * 100 / maxCheck) : (int)(100 * (numbersProcessed / maxCheck)),
                ProgressStatus = string.Format("Base = {0} : n = {1}  : processed {2} of {3}", radix, n, numbersProcessed, maxCheck)
            };
            progress.Report(report);
            var options = new ParallelOptions()
            {
                CancellationToken = token,
                MaxDegreeOfParallelism = maxProcessors
            };
            Parallel.For(0, loopSize, options, () => new MatrixPalindromicityResult(n), (i, state, subResult) =>
            {
                var minNumber = i * chunkSize + offset;
                var maxNumber = (i + 1) * chunkSize + offset;
                var iterationResult = CheckSets(minNumber, maxNumber, radix, n, maxSetNumber, rotations, permutationsOnly);
                // If the matrix was proven not to be palindromic we can stop processing
                if (!iterationResult.IsMatrixPalindromic)
                {
                    subResult.IsMatrixPalindromic = false;
                    subResult.FailedNumber = iterationResult.FailedNumber;
                    subResult.FailedSetType = iterationResult.FailedSetType;
                    state.Stop();
                }
                for (int j = 1; j <= n; j++)
                {
                    subResult.SelfPalindromicSets[j] += iterationResult.SelfPalindromicSets[j];
                    subResult.PairedPalindromicSets[j] += iterationResult.PairedPalindromicSets[j];
                }
                var numsProcessed = Interlocked.Add(ref numbersProcessed, chunkSize);
                report.PercentageCompleted = numsProcessed < long.MaxValue / 100 ? (int)(numsProcessed * 100 / maxCheck) : (int)(100 * (numsProcessed / maxCheck));
                report.ProgressStatus = string.Format("Base = {0} : n = {1}  : processed {2} of {3}", radix, n, numsProcessed, maxCheck);
                progress.Report(report);
                // Check if the user cancelled the operation
                options.CancellationToken.ThrowIfCancellationRequested();
                return subResult;
            },
            (threadResult) =>
            {
                lock (result)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        result.SelfPalindromicSets[j] += threadResult.SelfPalindromicSets[j];
                        result.PairedPalindromicSets[j] += threadResult.PairedPalindromicSets[j];
                    }
                }
            });
            return result;
        }

        /// <summary>
        /// Check the sets within the matrix for palindromicity
        /// </summary>
        /// <param name="minNumber">The minimum number of the chunk to be checked</param>
        /// <param name="maxNumber">The maximum number of the chunk to be checked</param>
        /// <param name="radix">The base of the matrix being checked</param>
        /// <param name="n">The n value of the matrix being checked</param>
        /// <param name="maxSetNumber">The maximum number below the mean of the matrix to be checked</param>
        /// <param name="rotations">The number of rotations required to create a set of sequences</param>
        /// <param name="permutationsOnly">Indicates whether to check permutations only</param>
        /// <returns></returns>
        private MatrixPalindromicityResult CheckSets(long minNumber, long maxNumber, long radix, long n, long maxSetNumber, long rotations, bool permutationsOnly)
        {
            var result = new MatrixPalindromicityResult(n);
            result.IsMatrixPalindromic = true;
            for (var i = minNumber; i < maxNumber; i++)
            {
                // Get the list of sequences to check
                var sequences = GetSequences(i, radix, n, maxSetNumber, rotations,  permutationsOnly);
                // GetSequences will return null if they have already been checked
                if (sequences != null)
                {
                    var count = sequences.Count;
                    RemoveSelfPalindromicPairs(sequences, maxSetNumber);
                    // If all self palindromic pairs have been removed then the sequences list is self palindromic and we check the next list of sequences
                    if (sequences.Count == 0)
                    {
                        result.SelfPalindromicSets[count / 2]++;
                        continue;
                    }
                    // If only some of the sequences in the list were self palindromic pairs then the theory is disproved otherwise we keep checking
                    if (sequences.Count != count)
                    {
                        result.IsMatrixPalindromic = false;
                        result.FailedNumber = i;
                        result.FailedSetType = SetType.SelfPaindromic;
                        return result;
                    }
                    // If there is a number in the sequence list that does not have a palindromic pair then it will be returned by
                    // IsPairedPalidromicSequence and the theory is disproved otherwise we keep checking
                    var pairedPaindromicResult = IsPairedPalidromicSequence(sequences, radix, n, maxSetNumber);
                    if (pairedPaindromicResult != -1)
                    {
                        result.IsMatrixPalindromic = false;
                        result.FailedNumber = pairedPaindromicResult;
                        result.FailedSetType = SetType.PairedPalindromic;
                        return result;
                    }
                    result.PairedPalindromicSets[count]++;
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the set of sequences to be checked
        /// </summary>
        /// <param name="currentNumber">The current matrix number being checked</param>
        /// <param name="radix">The base of the matrix being checked</param>
        /// <param name="n">The n value of the matrix being checked</param>
        /// <param name="maxSetNumber"></param>
        /// <param name="rotations">The number of rotations required to create a set of sequences</param>
        /// <param name="permutationsOnly">Indicates whether to check permutations only</param>
        /// <returns></returns>
        private List<NumberSequence> GetSequences(long currentNumber, long radix, long n, long maxSetNumber, long rotations, bool permutationsOnly)
        {
            var sequences = new List<NumberSequence>();
            var sequence = MathFunctions.ConvertLongToSequence(currentNumber, radix, n);
            // If permutations only then we only want sequences that have unique numbers
            if (permutationsOnly && sequence.Distinct().Count() != sequence.Length)
                return null;
            sequences.Add(new NumberSequence(currentNumber, sequence));
            var rotatedSequence = sequences[0].Sequence;
            // Add all unique rotations of the current sequence to the list
            for (var i = 0; i < rotations; i++)
            {
                rotatedSequence = rotatedSequence.RotateRight(1);
                var number = MathFunctions.ConvertSequenceToLong(rotatedSequence, radix);
                // If i is a rotation of a smaller value then the set has already been checked
                if (number < currentNumber || (maxSetNumber - number) < currentNumber)
                {
                    return null;
                }
                // Only add unique sequences to the list
                if (sequences.Any(s => s.Number == number))
                    continue;
                sequences.Add(new NumberSequence(number, rotatedSequence));
            }
            return sequences;
        }

        /// <summary>
        /// Removes all pairs of sequences that are equidistant from above and below the mean of the matrix
        /// </summary>
        /// <param name="sequences"></param>
        /// <param name="maxSetNumber"></param>
        private void RemoveSelfPalindromicPairs(List<NumberSequence> sequences, long maxSetNumber)
        {
            while (sequences.Count > 0)
            {
                var match = sequences.FirstOrDefault(s => s.Number == maxSetNumber - sequences[0].Number);
                if (match == null)
                    break;
                sequences.RemoveAt(0);
                sequences.Remove(match);
            }
        }

        /// <summary>
        /// Checks if all sequences within a set have a matching pair equidistant from the mean of the matrix
        /// Returns -1 if all sequences are paired or the value of the first unpaired sequence if found
        /// </summary>
        /// <param name="sequences">The set of sequences to check</param>
        /// <param name="radix">The base of the matrix being checked</param>
        /// <param name="n">The n value of the matrix being checked</param>
        /// <param name="maxSetNumber">The maximum number below the mean of the matrix to be checked</param>
        /// <returns></returns>
        private long IsPairedPalidromicSequence(List<NumberSequence> sequences, long radix, long n, long maxSetNumber)
        {
            var rotatedSequence = MathFunctions.ConvertLongToSequence(maxSetNumber - sequences[0].Number, radix, n);
            sequences.RemoveAt(0);
            for (var j = 0; j < sequences.Count; j++)
            {
                rotatedSequence = rotatedSequence.RotateRight(1);
                // If there is no paired palindromic sequence in the list of sequences then the theory is disproved
                if (MathFunctions.ConvertSequenceToLong(rotatedSequence, radix) != maxSetNumber - sequences[j].Number)
                {
                    return sequences[j].Number;
                }
            }
            return -1;
        }

        #endregion
    }
}
