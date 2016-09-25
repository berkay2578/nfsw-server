using System.Windows.Forms;

namespace AddonManager
{
    public partial class HelpLanguageForm : Form
    {
        public HelpLanguageForm()
        {
            InitializeComponent();

            avalonEditProxyLanguage.textEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("XML");
            avalonEditProxyLanguage.textEditor.Text = Properties.Resources.English;
            avalonEditProxyLanguage.textEditor.IsReadOnly = true;
        }

        private void HelpLanguageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}