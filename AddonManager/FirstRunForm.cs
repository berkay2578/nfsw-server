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
                Access.appSettings.hasRunAddonManagerBefore = true;
                Access.appSettings.saveInstance();
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