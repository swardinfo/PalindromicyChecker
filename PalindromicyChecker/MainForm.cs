using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalindromicyChecker
{
    /// <summary>
    /// The main form of the application
    /// </summary>
    public partial class MainForm : Form
    {
        #region Private Members

        long mChunkSize;
        long mMax;
        bool mInitializingComboBoxItems;
        CancellationTokenSource mCts;

        #endregion

        #region Constructor

        /// <summary>
        /// The constructor for the Main form
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Icon = ResourceManager.GetIcon("Grid_small.ico");
            var fontFamily = ResourceManager.GetFontFamily("Ubuntu-Regular.ttf");
            if (fontFamily != null)
                Font = new Font(fontFamily, 10);
            // Change mMax to set the maximum value for Max Base b and Max n
            mMax = 10;
            InitializeComboBoxes();
            // Change mChunkSize to set the number of numbers to be processed in each parallel operation
            mChunkSize = 5000;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// The event handler for the Process button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Process_Click(object sender, EventArgs e)
        {
            Process.Enabled = false;
            Cancel.Enabled = true;
            StringBuilder sb = new StringBuilder();
            mCts = new CancellationTokenSource();
            var token = mCts.Token;
            var progress = new Progress<ProgressReportModel>();
            progress.ProgressChanged += Progress_ProgressChanged;
            // Create the functions used to test if the given matrix is palindromic
            var palindromicFunctions = new PalindromicFunctions();
            bool result = true;
            Output.Clear();
            var minRadix = ((Item)MinRadix.SelectedItem).Value;
            var maxRadix = ((Item)MaxRadix.SelectedItem).Value;
            var minN = ((Item)MinN.SelectedItem).Value;
            var maxN = ((Item)MaxN.SelectedItem).Value;
            var cpus = (int)((Item)CpuCores.SelectedItem).Value;
            Output.Text = PermutationsOnly.Checked ? string.Format("Checking palindromicity for permutations only for Base = {0} to {1}\r\n\r\n", minRadix, maxRadix)
                : string.Format("Checking palindromicity for Base = {0} to {1} and n = {2} to {3}\r\n\r\n", minRadix, maxRadix, minN, maxN);
            var processStopwatch = new Stopwatch();
            var totalProcessStopwatch = new Stopwatch();
            totalProcessStopwatch.Start();
            try
            {
                for (long radix = minRadix; radix <= maxRadix; radix++)
                {
                    for (long n = minN; n <= maxN; n++)
                    {
                        if (PermutationsOnly.Checked && radix != n)
                            continue;
                        processStopwatch.Start();
                        // Test if the given matrix is palindromic
                        var subResult = await Task.Run(() => palindromicFunctions.IsMatrixPalindromicAsync(radix, n, token, progress, mChunkSize, PermutationsOnly.Checked, cpus));
                        processStopwatch.Stop();
                        PrintResult(radix, n, subResult, PermutationsOnly.Checked);
                        processStopwatch.Reset();
                        if (!subResult.IsMatrixPalindromic)
                        {
                            result = false;
                            break;
                        }
                    }
                }
                _ = result ? sb.AppendLine("Processing finished successfully\r\nAll matrices were palindromic") : sb.AppendLine("Process finished but theory was disproved\r\nOne or more matrices were not palindromic");
                sb.AppendLine("See above for details");
            }
            catch (OperationCanceledException ocex)
            {
                if (ocex.CancellationToken == token)
                {
                    MessageBox.Show("Operation cancelled by user");
                }
                else
                {
                    sb.AppendLine("The following error message was returned");
                    sb.AppendLine(ocex.Message.ToString());
                    sb.AppendLine(ocex.StackTrace.ToString());
                    if (ocex.InnerException != null)
                        sb.AppendLine(ocex.InnerException.ToString());
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine("The following error message was returned");
                sb.AppendLine(ex.ToString());
                sb.AppendLine(ex.StackTrace.ToString());
                if (ex.InnerException != null)
                    sb.AppendLine(ex.InnerException.ToString());
            }
            finally
            {
                mCts.Dispose();
            }
            sb.AppendLine();
            processStopwatch.Stop();
            totalProcessStopwatch.Stop();
            sb.AppendLine(string.Format("Total process time (hh:mm:ss.sss) = {0:hh\\:mm\\:ss}.{1:000}", totalProcessStopwatch.Elapsed, totalProcessStopwatch.Elapsed.Milliseconds));
            Output.Text += sb.ToString();
            Cancel.Enabled = false;
            Process.Enabled = true;
            Status.Text = "Processing completed";
            ProgressBar.Value = 0;
        }

        /// <summary>
        /// The event handler for the cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, EventArgs e)
        {
            if (mCts != null)
                mCts.Cancel();
        }

        /// <summary>
        /// The event handler for the Help button to open the Help window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Help_Click(object sender, EventArgs e)
        {
            var helpForm = new HelpForm();
            helpForm.StartPosition = FormStartPosition.Manual;
            helpForm.Location = new Point(Location.X + (Width - helpForm.Width) / 2, Location.Y + (Height - helpForm.Height) / 2);
            helpForm.Show();
        }

        private void About_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        /// <summary>
        /// Updates the status to indicate the number of numbers that have been processed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Progress_ProgressChanged(object sender, ProgressReportModel e)
        {
            ProgressBar.Value = e.PercentageCompleted;
            Status.Text = e.ProgressStatus;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event for all Comboboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mInitializingComboBoxItems)
                return;
            var comboBox = (ComboBox)sender;
            MinRadix.SelectedIndex = comboBox.Name == "MaxRadix" && MinRadix.SelectedIndex > MaxRadix.SelectedIndex ? MaxRadix.SelectedIndex : MinRadix.SelectedIndex;
            MaxRadix.SelectedIndex = comboBox.Name == "MinRadix" && MinRadix.SelectedIndex > MaxRadix.SelectedIndex ? MinRadix.SelectedIndex : MaxRadix.SelectedIndex;
            MinN.SelectedIndex = comboBox.Name == "MaxN" && MinN.SelectedIndex > MaxN.SelectedIndex ? MaxN.SelectedIndex : MinN.SelectedIndex;
            MaxN.SelectedIndex = comboBox.Name == "MinN" && MinN.SelectedIndex > MaxN.SelectedIndex ? MinN.SelectedIndex : MaxN.SelectedIndex;
            MinN.SelectedIndex = comboBox.Name == "MinRadix" && PermutationsOnly.Checked ? MinRadix.SelectedIndex : MinN.SelectedIndex;
            MaxN.SelectedIndex = comboBox.Name == "MaxRadix" && PermutationsOnly.Checked ? MaxRadix.SelectedIndex : MaxN.SelectedIndex;
        }

        /// <summary>
        /// The event handler for the PermutationsOnly.CheckedChanged event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PermutationsOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (PermutationsOnly.Checked)
            {
                MinN.SelectedIndex = MinRadix.SelectedIndex;
                MaxN.SelectedIndex = MaxRadix.SelectedIndex;
            }
            MinN.Enabled = !PermutationsOnly.Checked;
            MaxN.Enabled = !PermutationsOnly.Checked;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initialize the values in the min/max Comboboxes
        /// </summary>
        private void InitializeComboBoxes()
        {
            mInitializingComboBoxItems = true;
            foreach (var comboBox in Controls.OfType<ComboBox>())
            {
                comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "ValueX";
                var max = comboBox.Name == "CpuCores" ? Environment.ProcessorCount : mMax;
                var min = comboBox.Name == "CpuCores" ? 1 : 2;
                for (long i = min; i <= max; i++)
                {
                    comboBox.Items.Add(new Item(i));
                }
                comboBox.SelectedItem = comboBox.Name.Contains("Max") ? comboBox.Items.Cast<Item>().SingleOrDefault(item => item.Value == max) 
                                                                        : comboBox.Items.Cast<Item>().SingleOrDefault(item => item.Value == min);
            }
            mInitializingComboBoxItems = false;
        }

        /// <summary>
        /// Prints the result of processing a number set to the textbox
        /// </summary>
        /// <param name="radix">The base of the set being tested</param>
        /// <param name="n">The n value of the set being tested</param>
        /// <param name="result">The result of the test process</param>
        /// <param name="processTime">The time taken to process the set</param>
        private void PrintResult(long radix, long n, MatrixPalindromicityResult result, bool permutationsOnly)
        {
            var sb = new StringBuilder();
            long maxSetNumber = MathFunctions.GetMaxMatrixNumber(radix, n);
            if (permutationsOnly)
                sb.AppendLine(string.Format("### Permutations for Base = {0} ###", radix));
            sb.Append(string.Format("Base = {0}, n = {1}", radix, n));
            _ = result.IsMatrixPalindromic == true ? sb.AppendLine(": Matrix is palindromic") : sb.AppendLine(" : !!! Matrix is NOT palindromic");
            sb.AppendLine(string.Format("Maximum matrix number = {0}", maxSetNumber));
            if (maxSetNumber % 2 == 0)
            {
                var sequence = MathFunctions.ConvertLongToSequence(maxSetNumber / 2, radix, n);
                var sequenceText = string.Join(", ", sequence);
                sb.AppendLine(string.Format("Median = {0}, median sequence = {1}", maxSetNumber / 2, sequenceText));
            }
            if (result.IsMatrixPalindromic)
            {
                long totalPairs = 0;
                long totalPairedSets = 0;
                long totalSets = 0;
                foreach (var pair in result.PairedPalindromicSets)
                {
                    if (pair.Value != 0)
                    {
                        sb.AppendLine(string.Format("{0} paired palindromic sets = {1:n0}", pair.Key, pair.Value));
                        totalPairs += pair.Key * pair.Value;
                        totalPairedSets += pair.Value;
                        totalSets += 2 * pair.Value;
                    }
                }
                foreach (var pair in result.SelfPalindromicSets)
                {
                    if (pair.Value != 0)
                    {
                        sb.AppendLine(string.Format("{0} paired self-palindromic sets = {1:n0}", pair.Key, pair.Value));
                        totalPairs += pair.Key * pair.Value;
                        totalPairedSets += pair.Value;
                        totalSets += pair.Value;
                    }
                }

                // Used to verify the pair finding algorithms are checking all possible pairs
                long calculatedTotalPairs;
                if (PermutationsOnly.Checked)
                {
                    calculatedTotalPairs = MathFunctions.Factorial(n) / 2;
                }
                else
                {
                    calculatedTotalPairs = (long)Math.Ceiling((double)maxSetNumber / 2);
                }
                if (totalPairs != calculatedTotalPairs)
                {
                    sb.AppendLine(string.Format("!!!!! Total pairs should be {0} but are {1} !!!!!", calculatedTotalPairs, totalPairs));
                }
                else
                {
                    sb.AppendLine(string.Format("Total pairs = {0:n0}", totalPairs));
                    sb.AppendLine(string.Format("Total paired sets = {0:n0}", totalPairedSets));
                    sb.AppendLine(string.Format("Total sets = {0:n0}", totalSets));
                }
            }
            else
            {
                sb.AppendLine();
                sb.AppendLine("FAILED-FAILED-FAILED-FAILED-FAILED-FAILED-FAILED-FAILED");
                string setType = result.FailedSetType == SetType.PairedPalindromic ? "paired palindromic" : "self palindromic";
                sb.AppendLine(string.Format("Matrix failed on {0} and set type {1}", result.FailedNumber, setType));
                sb.AppendLine("FAILED-FAILED-FAILED-FAILED-FAILED-FAILED-FAILED-FAILED");
                sb.AppendLine();
            }
            sb.AppendLine();
            Output.Text += sb.ToString();
        }

        #endregion
    }
}
