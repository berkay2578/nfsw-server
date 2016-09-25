namespace AddonManager
{
    partial class HelpLanguageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.elementHostLanguage = new System.Windows.Forms.Integration.ElementHost();
            this.avalonEditProxyLanguage = new AddonManager.AvalonEditProxy();
            this.SuspendLayout();
            // 
            // elementHostLanguage
            // 
            this.elementHostLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHostLanguage.Location = new System.Drawing.Point(0, 0);
            this.elementHostLanguage.Name = "elementHostLanguage";
            this.elementHostLanguage.Size = new System.Drawing.Size(284, 413);
            this.elementHostLanguage.TabIndex = 0;
            this.elementHostLanguage.Child = this.avalonEditProxyLanguage;
            // 
            // HelpLanguageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 413);
            this.Controls.Add(this.elementHostLanguage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "HelpLanguageForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Default (English) Language File";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HelpLanguageForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHostLanguage;
        private AvalonEditProxy avalonEditProxyLanguage;
    }
}