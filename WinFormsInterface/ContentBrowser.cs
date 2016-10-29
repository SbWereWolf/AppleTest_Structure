using System;
using System.Windows.Forms;

namespace WinFormsInterface
{
    public partial class ContentBrowser : Form
    {
        public ContentBrowser()
        {
            InitializeComponent();
        }

        private void RefreshToolStripButton_Click(object sender, EventArgs e)
        {
            InterfaceHandler.RefreshList(RecordsDataGridView);
        }

        private void AddToolStripButton_Click(object sender, EventArgs e)
        {
            var viewForm = new ContentView(null);
            viewForm.Show();
        }

        private void EditToolStripButton_Click(object sender, EventArgs e)
        {
            var contentRecord = InterfaceHandler.GetGridContentRecord(RecordsDataGridView);

            var viewForm = new ContentView(contentRecord);
            viewForm.Show();
        }

        private void DeleteToolStripButton_Click(object sender, EventArgs e)
        {
            InterfaceHandler.DeleteRecord(RecordsDataGridView);
        }
    }
}
