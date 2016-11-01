using System;
using System.Windows.Forms;
using BusinessLogic;

namespace WinFormsInterface
{
    public partial class HierarchyView : Form
    {
        private readonly HierarchyEntity _hierarchyEntity;

        private HierarchyEntity HierarchyEntity
        {
            get { return _hierarchyEntity; }
        }

        public HierarchyView(HierarchyEntity hierarchyEntity)
        {
            _hierarchyEntity = hierarchyEntity;
            InitializeComponent();
        }

        private void CancelToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ApplyToolStripButton_Click(object sender, EventArgs e)
        {
            var name = string.Empty;
            if (NameTextBox != null )
            {
                 name = NameTextBox.Text;
            }
            
            var record = HierarchyEntity;
            
            InterfaceHandler.SaveHierarchyEntity(this, record, name);
        }

        private void HierarchyView_Load(object sender, EventArgs e)
        {
            if (HierarchyEntity != null)
            {
                if (NameTextBox != null)
                {
                    NameTextBox.Text = HierarchyEntity.Name;
                }

            }
        }
    }
}
