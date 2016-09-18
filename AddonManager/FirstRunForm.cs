using System;
using System.Windows.Forms;

namespace AddonManager
{
    public partial class FirstRunForm : Form
    {
        public FirstRunForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["hasRunManagerBefore"] = true;
            Properties.Settings.Default.Save();
            MainForm mainForm = new MainForm(true);
            mainForm.Show();
            this.Hide();
        }
    }
}
