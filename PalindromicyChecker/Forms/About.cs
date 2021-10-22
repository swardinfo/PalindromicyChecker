using System;
using System.Drawing;
using System.Windows.Forms;

namespace PalindromicyChecker
{
    /// <summary>
    /// A form to show about information to the user
    /// </summary>
    public partial class AboutForm : Form
    {
        #region Constructors

        /// <summary>
        /// The constructor for the About form
        /// </summary>
        public AboutForm()
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
        /// The event handler for the About form's Shown event
        /// </summary>
        /// <param name="sender">The form that raised this event</param>
        /// <param name="e">The event args for this event</param>
        private void AboutForm_Shown(object sender, EventArgs e)
        {
            About.Select(0, 0);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Overrides the ProcessCmdKey so that the escape key can be used to close the About form
        /// </summary>
        /// <param name="msg">The Windows Forms message</param>
        /// <param name="keyData">Data from the key that was pressed</param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion
    }
}
