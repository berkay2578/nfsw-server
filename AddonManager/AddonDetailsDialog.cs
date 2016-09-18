using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.WinForms;

namespace AddonManager
{
    public partial class AddonDetailsDialog : Form
    {
        public String[] returnValues { get; set; }
        private HtmlPanel htmlPanel;

        private String wrapWithDefaultFontTag(String sourceStr)
        {
            return String.Format("{0}{1}{2}", "<font face=\"Microsoft Sans Serif\" size=\"8.25pt\">", sourceStr, "</font>");
        }

        private void addonDescriptionUseDefaultFontCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int allowedLength = Addon.addonDescriptionDef[2] - 1 - (addonDescriptionUseDefaultFontCheckBox.Checked ? 52 : 0);
            detailsAddonDescriptionMaxLabel.Text = String.Format("Description: (supports html, max {0} chars)", allowedLength);
            detailsAddonDescriptionEditor.MaxLength = allowedLength;
            if (detailsAddonDescriptionEditor.Text.Length > allowedLength)
                detailsAddonDescriptionEditor.Text = detailsAddonDescriptionEditor.Text.Substring(0, allowedLength);
        }

        private void refreshDemoLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                htmlPanel.Text = addonDescriptionUseDefaultFontCheckBox.Checked ?
                    wrapWithDefaultFontTag(detailsAddonDescriptionEditor.Text) : detailsAddonDescriptionEditor.Text;
            }
            catch (Exception)
            {
                htmlPanel.Text = "Oops";
                MessageBox.Show("Couldn't render the HTML input, please review your description and retry.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            returnValues = new string[4];
            returnValues[0] = detailsAddonNameTextBox.Text;
            returnValues[1] = detailsAddonCreatorTextBox.Text;
            returnValues[2] = detailsAddonVersionTextBox.Text;
            returnValues[3] = addonDescriptionUseDefaultFontCheckBox.Checked ?
                    wrapWithDefaultFontTag(detailsAddonDescriptionEditor.Text) : detailsAddonDescriptionEditor.Text;
            DialogResult = DialogResult.OK;
        }

        public AddonDetailsDialog(String addonNameText, String addonTypeText, String addonCreatorText, String addonVersionText, String addonDescriptionText)
        {
            InitializeComponent();

            detailsAddonNameMaxLabel.Text = String.Format(detailsAddonNameMaxLabel.Text, Addon.addonNameDef[2] - 1);
            detailsAddonNameTextBox.MaxLength = Addon.addonNameDef[2] - 1;
            detailsAddonCreatorMaxLabel.Text = String.Format(detailsAddonCreatorMaxLabel.Text, Addon.addonCreatorDef[2] - 1);
            detailsAddonCreatorTextBox.MaxLength = Addon.addonCreatorDef[2] - 1;
            detailsAddonVersionMaxLabel.Text = String.Format(detailsAddonVersionMaxLabel.Text, Addon.addonVersionDef[2] - 1);
            detailsAddonVersionTextBox.MaxLength = Addon.addonVersionDef[2] - 1;
            detailsAddonDescriptionMaxLabel.Text = String.Format(detailsAddonDescriptionMaxLabel.Text, Addon.addonDescriptionDef[2] - 1);
            detailsAddonDescriptionEditor.MaxLength = Addon.addonDescriptionDef[2] - 1;

            detailsAddonNameTextBox.Text = addonNameText;
            detailsAddonTypeTextBox.Text = addonTypeText;
            detailsAddonCreatorTextBox.Text = addonCreatorText;
            detailsAddonDateTextBox.Text = DateTime.Now.ToShortDateString();
            detailsAddonVersionTextBox.Text = addonVersionText;
            detailsAddonOfflineServerVersionTextBox.Text = MainForm.localOfflineServerVersion;
            if (addonDescriptionText.StartsWith("<font face=\"Microsoft Sans Serif\" size=\"8pt\">") && addonDescriptionText.EndsWith("</font>"))
            {
                addonDescriptionText = addonDescriptionText.Remove(addonDescriptionText.Length - 7, 7).Remove(0, 45);
                addonDescriptionUseDefaultFontCheckBox.Checked = true;
            }
            else
            {
                if (addonDescriptionText.Length > (Addon.addonDescriptionDef[2] - 53))
                {
                    addonDescriptionUseDefaultFontCheckBox.Checked = false;
                }
            }
            detailsAddonDescriptionEditor.Text = addonDescriptionText;

            htmlPanel = new HtmlPanel();
            htmlPanel.AutoSize = false;
            htmlPanel.BorderStyle = BorderStyle.Fixed3D;
            htmlPanel.Location = new Point(622, 37);
            htmlPanel.Size = new Size(210, 299);
            htmlPanel.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            this.Controls.Add(htmlPanel);
        }
    }
}