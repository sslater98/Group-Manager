using System;
using System.Windows.Forms;

namespace GroupManager
{
    public partial class Options : Form
    {
        private static Options inst;

        public static Options GetForm
        {
            get
            {
                try
                {
                    inst = new Options();
                    return inst;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("About to return new form");
#if (DEBUG == true)
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
#endif
                    return null;
                }
            }
        }

        public Options()
        {
            InitializeComponent();
            this.txtbxCurrentPath.Text = GroupManager.Properties.Settings.Default.defaultFileLocation;
        }

        private void btnCancel_Click(Object sender, EventArgs e)
        {
            inst.Close();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (txtbxPath.Text != null)
                GroupManager.Properties.Settings.Default.defaultFileLocation = txtbxPath.Text;

            GroupManager.Properties.Settings.Default.Save();

            inst.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}