using System;
using System.Windows.Forms;
using BusinessLogic;

namespace WinFormsInterface
{
    public partial class HierarchyStructure : Form
    {
        private readonly HierarchyEntity _hierarchyEntity;

        private HierarchyEntity HierarchyEntity
        {
            get { return _hierarchyEntity; }
        }

        public HierarchyStructure(HierarchyEntity hierarchyEntity)
        {
            _hierarchyEntity = hierarchyEntity;
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
