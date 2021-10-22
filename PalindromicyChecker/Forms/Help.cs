using System;
using System.Drawing;
using System.Windows.Forms;

namespace PalindromicyChecker
{
    /// <summary>
    /// A form to show help information to the user
    /// </summary>
    internal partial class HelpForm : Form
    {
        #region Constructors

        /// <summary>
        /// The constructor for the Help form
        /// </summary>
        public HelpForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            Icon = ResourceManager.GetIcon("Grid_small.ico");
            var fontFamily = ResourceManager.GetFontFamily("Ubuntu-Regular.ttf");
            if (fontFamily != null)
                Font = new Font(fontFamily, 10);
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// The event handler for the Help Form's Shown event
        /// </summary>
        /// <param name="sender">The form that raised this event</param>
        /// <param name="e">The event args for this event</param>
        private void HelpForm_Shown(object sender, EventArgs e)
        {
            Help.Select(0, 0);
        }

        #endregion
    }
}
