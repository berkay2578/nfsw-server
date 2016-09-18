using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
