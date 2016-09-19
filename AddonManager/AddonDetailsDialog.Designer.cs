namespace AddonManager
{
    partial class AddonDetailsDialog
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.detailsAddonNameTextBox = new System.Windows.Forms.TextBox();
            this.detailsAddonTypeTextBox = new System.Windows.Forms.TextBox();
            this.detailsAddonDateTextBox = new System.Windows.Forms.TextBox();
            this.detailsAddonCreatorTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.detailsAddonOfflineServerVersionTextBox = new System.Windows.Forms.TextBox();
            this.detailsAddonVersionTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.detailsAddonDescriptionMaxLabel = new System.Windows.Forms.Label();
            this.detailsAddonNameMaxLabel = new System.Windows.Forms.Label();
            this.detailsAddonCreatorMaxLabel = new System.Windows.Forms.Label();
            this.detailsAddonVersionMaxLabel = new System.Windows.Forms.Label();
            this.detailsAddonDescriptionEditor = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.refreshDemoLabel = new System.Windows.Forms.LinkLabel();
            this.addonDescriptionUseDefaultFontCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(674, 344);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(755, 344);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Type: ";
            // 
            // detailsAddonNameTextBox
            // 
            this.detailsAddonNameTextBox.Location = new System.Drawing.Point(117, 18);
            this.detailsAddonNameTextBox.MaxLength = 0;
            this.detailsAddonNameTextBox.Name = "detailsAddonNameTextBox";
            this.detailsAddonNameTextBox.Size = new System.Drawing.Size(124, 20);
            this.detailsAddonNameTextBox.TabIndex = 7;
            // 
            // detailsAddonTypeTextBox
            // 
            this.detailsAddonTypeTextBox.Location = new System.Drawing.Point(117, 49);
            this.detailsAddonTypeTextBox.MaxLength = 0;
            this.detailsAddonTypeTextBox.Name = "detailsAddonTypeTextBox";
            this.detailsAddonTypeTextBox.ReadOnly = true;
            this.detailsAddonTypeTextBox.Size = new System.Drawing.Size(124, 20);
            this.detailsAddonTypeTextBox.TabIndex = 8;
            // 
            // detailsAddonDateTextBox
            // 
            this.detailsAddonDateTextBox.Location = new System.Drawing.Point(117, 111);
            this.detailsAddonDateTextBox.MaxLength = 0;
            this.detailsAddonDateTextBox.Name = "detailsAddonDateTextBox";
            this.detailsAddonDateTextBox.ReadOnly = true;
            this.detailsAddonDateTextBox.Size = new System.Drawing.Size(124, 20);
            this.detailsAddonDateTextBox.TabIndex = 12;
            // 
            // detailsAddonCreatorTextBox
            // 
            this.detailsAddonCreatorTextBox.Location = new System.Drawing.Point(117, 80);
            this.detailsAddonCreatorTextBox.MaxLength = 0;
            this.detailsAddonCreatorTextBox.Name = "detailsAddonCreatorTextBox";
            this.detailsAddonCreatorTextBox.Size = new System.Drawing.Size(124, 20);
            this.detailsAddonCreatorTextBox.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Created on: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Creator: ";
            // 
            // detailsAddonOfflineServerVersionTextBox
            // 
            this.detailsAddonOfflineServerVersionTextBox.Location = new System.Drawing.Point(117, 173);
            this.detailsAddonOfflineServerVersionTextBox.MaxLength = 0;
            this.detailsAddonOfflineServerVersionTextBox.Name = "detailsAddonOfflineServerVersionTextBox";
            this.detailsAddonOfflineServerVersionTextBox.ReadOnly = true;
            this.detailsAddonOfflineServerVersionTextBox.Size = new System.Drawing.Size(124, 20);
            this.detailsAddonOfflineServerVersionTextBox.TabIndex = 16;
            // 
            // detailsAddonVersionTextBox
            // 
            this.detailsAddonVersionTextBox.Location = new System.Drawing.Point(117, 142);
            this.detailsAddonVersionTextBox.MaxLength = 0;
            this.detailsAddonVersionTextBox.Name = "detailsAddonVersionTextBox";
            this.detailsAddonVersionTextBox.Size = new System.Drawing.Size(124, 20);
            this.detailsAddonVersionTextBox.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Made for version: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Version: ";
            // 
            // detailsAddonDescriptionMaxLabel
            // 
            this.detailsAddonDescriptionMaxLabel.AutoSize = true;
            this.detailsAddonDescriptionMaxLabel.Location = new System.Drawing.Point(365, 21);
            this.detailsAddonDescriptionMaxLabel.Name = "detailsAddonDescriptionMaxLabel";
            this.detailsAddonDescriptionMaxLabel.Size = new System.Drawing.Size(205, 13);
            this.detailsAddonDescriptionMaxLabel.TabIndex = 17;
            this.detailsAddonDescriptionMaxLabel.Text = "Description: (supports html, max {0} chars)";
            // 
            // detailsAddonNameMaxLabel
            // 
            this.detailsAddonNameMaxLabel.AutoSize = true;
            this.detailsAddonNameMaxLabel.Location = new System.Drawing.Point(247, 21);
            this.detailsAddonNameMaxLabel.Name = "detailsAddonNameMaxLabel";
            this.detailsAddonNameMaxLabel.Size = new System.Drawing.Size(78, 13);
            this.detailsAddonNameMaxLabel.TabIndex = 18;
            this.detailsAddonNameMaxLabel.Text = "(max {0} chars)";
            // 
            // detailsAddonCreatorMaxLabel
            // 
            this.detailsAddonCreatorMaxLabel.AutoSize = true;
            this.detailsAddonCreatorMaxLabel.Location = new System.Drawing.Point(247, 83);
            this.detailsAddonCreatorMaxLabel.Name = "detailsAddonCreatorMaxLabel";
            this.detailsAddonCreatorMaxLabel.Size = new System.Drawing.Size(78, 13);
            this.detailsAddonCreatorMaxLabel.TabIndex = 19;
            this.detailsAddonCreatorMaxLabel.Text = "(max {0} chars)";
            // 
            // detailsAddonVersionMaxLabel
            // 
            this.detailsAddonVersionMaxLabel.AutoSize = true;
            this.detailsAddonVersionMaxLabel.Location = new System.Drawing.Point(247, 145);
            this.detailsAddonVersionMaxLabel.Name = "detailsAddonVersionMaxLabel";
            this.detailsAddonVersionMaxLabel.Size = new System.Drawing.Size(78, 13);
            this.detailsAddonVersionMaxLabel.TabIndex = 20;
            this.detailsAddonVersionMaxLabel.Text = "(max {0} chars)";
            // 
            // detailsAddonDescriptionEditor
            // 
            this.detailsAddonDescriptionEditor.Location = new System.Drawing.Point(368, 37);
            this.detailsAddonDescriptionEditor.Name = "detailsAddonDescriptionEditor";
            this.detailsAddonDescriptionEditor.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.detailsAddonDescriptionEditor.Size = new System.Drawing.Size(237, 283);
            this.detailsAddonDescriptionEditor.TabIndex = 21;
            this.detailsAddonDescriptionEditor.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(616, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Demo:";
            // 
            // refreshDemoLabel
            // 
            this.refreshDemoLabel.DisabledLinkColor = System.Drawing.Color.Blue;
            this.refreshDemoLabel.Location = new System.Drawing.Point(522, 322);
            this.refreshDemoLabel.Name = "refreshDemoLabel";
            this.refreshDemoLabel.Size = new System.Drawing.Size(83, 17);
            this.refreshDemoLabel.TabIndex = 23;
            this.refreshDemoLabel.TabStop = true;
            this.refreshDemoLabel.Text = "Refresh Demo";
            this.refreshDemoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.refreshDemoLabel.VisitedLinkColor = System.Drawing.Color.Blue;
            this.refreshDemoLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.refreshDemoLabel_LinkClicked);
            // 
            // addonDescriptionUseDefaultFontCheckBox
            // 
            this.addonDescriptionUseDefaultFontCheckBox.Location = new System.Drawing.Point(371, 322);
            this.addonDescriptionUseDefaultFontCheckBox.Name = "addonDescriptionUseDefaultFontCheckBox";
            this.addonDescriptionUseDefaultFontCheckBox.Size = new System.Drawing.Size(155, 19);
            this.addonDescriptionUseDefaultFontCheckBox.TabIndex = 24;
            this.addonDescriptionUseDefaultFontCheckBox.Text = "Wrap with default font tag";
            this.addonDescriptionUseDefaultFontCheckBox.UseVisualStyleBackColor = true;
            this.addonDescriptionUseDefaultFontCheckBox.CheckedChanged += new System.EventHandler(this.addonDescriptionUseDefaultFontCheckBox_CheckedChanged);
            // 
            // AddonDetailsDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(844, 376);
            this.Controls.Add(this.addonDescriptionUseDefaultFontCheckBox);
            this.Controls.Add(this.refreshDemoLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.detailsAddonDescriptionEditor);
            this.Controls.Add(this.detailsAddonVersionMaxLabel);
            this.Controls.Add(this.detailsAddonCreatorMaxLabel);
            this.Controls.Add(this.detailsAddonNameMaxLabel);
            this.Controls.Add(this.detailsAddonDescriptionMaxLabel);
            this.Controls.Add(this.detailsAddonOfflineServerVersionTextBox);
            this.Controls.Add(this.detailsAddonVersionTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.detailsAddonDateTextBox);
            this.Controls.Add(this.detailsAddonCreatorTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.detailsAddonTypeTextBox);
            this.Controls.Add(this.detailsAddonNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddonDetailsDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Addon Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox detailsAddonNameTextBox;
        private System.Windows.Forms.TextBox detailsAddonTypeTextBox;
        private System.Windows.Forms.TextBox detailsAddonDateTextBox;
        private System.Windows.Forms.TextBox detailsAddonCreatorTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox detailsAddonOfflineServerVersionTextBox;
        private System.Windows.Forms.TextBox detailsAddonVersionTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label detailsAddonDescriptionMaxLabel;
        private System.Windows.Forms.Label detailsAddonNameMaxLabel;
        private System.Windows.Forms.Label detailsAddonCreatorMaxLabel;
        private System.Windows.Forms.Label detailsAddonVersionMaxLabel;
        private System.Windows.Forms.RichTextBox detailsAddonDescriptionEditor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel refreshDemoLabel;
        private System.Windows.Forms.CheckBox addonDescriptionUseDefaultFontCheckBox;
    }
}