namespace PalindromicyChecker
{
    /// <summary>
    /// Holds the current status of a process for reporting to the UI
    /// </summary>
    public class ProgressReportModel
    {
        /// <summary>
        /// The percentage so far completed by the process
        /// </summary>
        public int PercentageCompleted { get; set; }

        /// <summary>
        /// A description of the progress so far completed
        /// </summary>
        public string ProgressStatus { get; set; }
    }
}
