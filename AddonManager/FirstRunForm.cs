using System.Windows.Forms;

namespace AddonManager
{
    public partial class FirstRunForm : Form
    {
        public FirstRunForm(Form parentForm = null)
        {
            InitializeComponent();
            this.BringToFront();

            okButton.Click += (s, e) => 
            {
                Properties.Settings.Default["hasRunManagerBefore"] = true;
                Properties.Settings.Default.Save();
                if (parentForm != null)
                {
                    parentForm.Opacity = 1d;
                    parentForm.Show();
                    parentForm.BringToFront();
                }
                this.Close();
            };
        }
    }
}