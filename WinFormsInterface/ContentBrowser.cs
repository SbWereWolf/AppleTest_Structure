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
            InterfaceHandler.AddRecord();
        }

        private void EditToolStripButton_Click(object sender, EventArgs e)
        {
            InterfaceHandler.EditRecord(RecordsDataGridView);
        }

        private void DeleteToolStripButton_Click(object sender, EventArgs e)
        {
            InterfaceHandler.DeleteRecord(RecordsDataGridView);
        }
    }
}
