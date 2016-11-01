using System;
using System.Windows.Forms;
using BusinessLogic;

namespace WinFormsInterface
{
    public partial class HierarchyStructure : Form
    {
        private HierarchyEntity HierarchyEntity { get; }

        public HierarchyStructure(HierarchyEntity hierarchyEntity)
        {
            HierarchyEntity = hierarchyEntity;
            InitializeComponent();
        }

        private void CancelToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SelectToolStripButton_Click(object sender, EventArgs e)
        {
            InterfaceHandler.MoveHierarchy(this, HierarchyEntity, HierarchyTreeView);
        }

        private void HierarchyView_Load(object sender, EventArgs e)
        {
            InterfaceHandler.RefreshTree(HierarchyTreeView);
        }

        private void RefreshToolStripButton_Click(object sender, EventArgs e)
        {
            InterfaceHandler.RefreshTree(HierarchyTreeView);
        }
    }
}
