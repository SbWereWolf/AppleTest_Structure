using System;
using System.Globalization;
using System.Windows.Forms;
using BusinessLogic;

namespace WinFormsInterface
{
    public partial class ContentView : Form
    {
        private Content.Record Record { get; }

        public ContentView(Content.Record record)
        {
            Record = record;
            InitializeComponent();
        }

        private void CancelToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ApplyToolStripButton_Click(object sender, EventArgs e)
        {
            var name = NameTextBox?.Text;
            var content = ContentTextBox?.Text;
            var record = Record;
            
            InterfaceHandler.Save(this,content, record, name);
        }

        private void ContentView_Load(object sender, EventArgs e)
        {
            if (Record != null)
            {
                if (NameTextBox != null)
                {
                    NameTextBox.Text = Record.Name;
                }
                if (ContentTextBox != null
                    && Record.ContentValue != null)
                {
                    ContentTextBox.Text = Record.ContentValue.Value.ToString(CultureInfo.InvariantCulture);
                }
            }
        }
    }
}
