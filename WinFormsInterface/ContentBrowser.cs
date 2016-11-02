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
            InterfaceHandler.LoadContent(HierarchyTreeView, RecordsDataGridView);
            //InterfaceHandler.RefreshList(RecordsDataGridView);
        }

        private void AddToolStripButton_Click(object sender, EventArgs e)
        {
            var hierarchyTreeView = HierarchyTreeView;
            var contentRecord = InterfaceHandler.SetContentByHierarchy(hierarchyTreeView);

            if (contentRecord!= null)
            {
                var viewForm = new ContentView(contentRecord);
                viewForm.Show();
            }
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

        private void RefreshHierarchyToolStripButton_Click(object sender, EventArgs e)
        {
            InterfaceHandler.RefreshTree(HierarchyTreeView);
        }

        private void HierarchyTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            InterfaceHandler.LoadContent(HierarchyTreeView, RecordsDataGridView);
        }

        private void AddHierarchyToolStripButton_Click(object sender, EventArgs e)
        {
            var entityWithParent = InterfaceHandler.SetHierarchyParentByTreeView(HierarchyTreeView);
            var viewForm = new HierarchyView(entityWithParent);
            viewForm.Show();
        }

        private void EditHierarchytoolStripButton_Click(object sender, EventArgs e)
        {
            var entity = InterfaceHandler.SetHierarchyEntityByTreeView(HierarchyTreeView);

            if (entity !=null )
            {
                var viewForm = new HierarchyView(entity);
                viewForm.Show();
            }
        }

        private void DeleteHierarchyToolStripButton_Click(object sender, EventArgs e)
        {
            InterfaceHandler.DeleteHierarchy(HierarchyTreeView);
        }

        private void MoveToolStripButton_Click(object sender, EventArgs e)
        {
            var entity = InterfaceHandler.SetHierarchyEntityByTreeView(HierarchyTreeView);

            if (entity != null)
            {
                var viewForm = new HierarchyStructure(entity);
                viewForm.Show();
            }
        }
    }
}
