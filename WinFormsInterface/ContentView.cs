using System;
using System.Globalization;
using System.Windows.Forms;
using BusinessLogic;

namespace WinFormsInterface
{
    public partial class ContentView : Form
    {
        private ContentEntity ContentEntity { get; }

        public ContentView(ContentEntity contentEntity)
        {
            ContentEntity = contentEntity;
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
            var record = ContentEntity;
            
            InterfaceHandler.SaveContetnEntity(this,content, record, name);
        }

        private void ContentView_Load(object sender, EventArgs e)
        {
            if (ContentEntity != null)
            {
                if (NameTextBox != null)
                {
                    NameTextBox.Text = ContentEntity.Name;
                }
                if (ContentTextBox != null
                    && ContentEntity.ContentValue != null)
                {
                    ContentTextBox.Text = ContentEntity.ContentValue.Value.ToString(CultureInfo.InvariantCulture);
                }
            }
        }
    }
}
