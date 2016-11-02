using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BusinessLogic;

namespace WinFormsInterface
{
    internal static class InterfaceHandler
    {
        public static void SaveContetnEntity(Form form, string content, ContentEntity contentEntity, string name)
        {
            float contentConverted;
            float? contentValue = null;
            var isSuccess = float.TryParse(content, NumberStyles.Float,CultureInfo.InvariantCulture, out contentConverted);
            if (isSuccess)
            {
                contentValue = contentConverted;
            }

            if (contentEntity != null)
            {
                contentEntity.ContentValue = contentValue;
                contentEntity.Name = name;
            }
            var businessLogic = new Content { EntityInstance = contentEntity };
            contentEntity = businessLogic.Set();

            var isSetSuccess = false;

            if (contentEntity != null)
            {
                isSetSuccess = contentEntity.Id.HasValue;
            }

            if (isSetSuccess)
            {
                if (form != null)
                {
                    form.Close();
                }
            }
            else
            {
                MessageBox.Show(@"Error on save");
            }
        }

        public static ContentEntity GetGridContentRecord( DataGridView dataGridView)
        {
            int? selectedCellCount = null;
            if (dataGridView != null )
            {
                selectedCellCount = dataGridView.SelectedCells.Count;
            }
            

            DataGridViewCell cellId = null;
            DataGridViewCell cellHierachyId = null;
            DataGridViewCell cellName = null;
            DataGridViewCell cellContentValue = null;
            if (selectedCellCount > 0)
            {
                var cell = dataGridView.SelectedCells[0];
                DataGridViewRow selectedRow = null;
                if (cell != null )
                {
                    selectedRow = cell.OwningRow;
                }
                if (selectedRow != null)
                {
                    cellId = selectedRow.Cells["Id"];
                    cellHierachyId = selectedRow.Cells["HierachyId"];
                    cellName = selectedRow.Cells["Name"];
                    cellContentValue = selectedRow.Cells["ContentValue"];
                }
            }
            var contentIdString = string.Empty;
            if (cellId != null )
            {
             if (cellId.Value != null)
            {
                contentIdString = cellId.Value.ToString();
            }               
            }

            var hierachyIdString = string.Empty;
            if (cellHierachyId != null )
            {
            if (cellHierachyId.Value != null)
            {
                hierachyIdString = cellHierachyId.Value.ToString();
            }                
            }

            var name = string.Empty;
            if (cellName != null )
            {
            if (cellName.Value != null)
            {
                name = cellName.Value.ToString();
            }                
            }

            var contentValueString = string.Empty;
            if (cellContentValue != null)
            {
                if (cellContentValue.Value != null)
                {
                    contentValueString = cellContentValue.Value.ToString();
                }
            }

            var conternRecord = new ContentEntity { Name = name };

            long contentId;
            var sSuccess = long.TryParse(contentIdString, out contentId);
            if (sSuccess)
            {
                conternRecord.Id = contentId;
            }
            long hierachyId;
            sSuccess = long.TryParse(hierachyIdString, out hierachyId);
            if (sSuccess)
            {
                conternRecord.HierachyId = hierachyId;
            }
            float contentValue;
            sSuccess = float.TryParse(contentValueString, out contentValue);
            if (sSuccess)
            {
                conternRecord.ContentValue = contentValue;
            }
            return conternRecord;
        }

        public static void DeleteRecord(DataGridView recordsDataGridView)
        {
            var contentRecord = GetGridContentRecord(recordsDataGridView);
            var handler = new Content { EntityInstance = contentRecord };
            var isSuccess = handler.Delete();
            if (!isSuccess)
            {
                MessageBox.Show(@"Error on delete");
            }
        }

        public static void RefreshTree(TreeView hierarchyTreeView)
        {
            var records = Hierarchy.GetAllHierarchies();

            if (hierarchyTreeView != null && records != null )
            {
                var nodes = hierarchyTreeView.Nodes;
                nodes.Clear();

                var nodesCache = new List<TreeNode>();
                foreach (var entity in records)
                {
                    if (entity != null)
                    {
                        var node = new TreeNode(entity.Name)
                        {
                            Tag = entity.Id,
                            Name = entity.Id.HasValue ? entity.Id.Value.ToString(CultureInfo.InvariantCulture) : string.Empty
                        };

                        var parent = entity.Parent;
                        var parentNode = (from treeNode in nodesCache let tag = treeNode == null ? null : (long?)treeNode.Tag where tag == parent select treeNode).FirstOrDefault();
                        if (parentNode == null)
                        {
                            nodes.Add(node);
                        }
                        else
                        {
                            parentNode.Nodes.Add(node);
                        }
                        nodesCache.Add(node);
                    }
                }
            }
        }


        public static void LoadContent(TreeView hierarchyTreeView, DataGridView recordsDataGridView)
        {
            TreeNode selectedNode = null;
            if (hierarchyTreeView != null )
            {
                selectedNode = hierarchyTreeView.SelectedNode;
            }
            if (selectedNode != null)
            {
                var hierarchyId = (long?)selectedNode.Tag;

                var businesLogic = new Content();
                var contentList = businesLogic.Get(null, hierarchyId);
                if (recordsDataGridView != null)
                {
                    recordsDataGridView.DataSource = contentList;
                }
            }
        }
        public static ContentEntity SetContentByHierarchy(TreeView hierarchyTreeView)
        {
            ContentEntity contentRecord = null;
            TreeNode selectedNode = null;
            if (hierarchyTreeView != null)
            {
                selectedNode = hierarchyTreeView.SelectedNode;
            }
            if (selectedNode != null)
            {
                var hierarchyId = (long?)selectedNode.Tag;

                contentRecord = new ContentEntity { HierachyId = hierarchyId };
            }
            return contentRecord;
        }

        public static void SaveHierarchyEntity(Form form, HierarchyEntity hierarchyEntity, string name)
        {
            if (hierarchyEntity != null)
            {
                hierarchyEntity.Name = name;
            }
            var businessLogic = new Hierarchy { EntityInstance = hierarchyEntity };
            hierarchyEntity = businessLogic.Set();

            var isSetSuccess = false;

            if (hierarchyEntity != null)
            {
                isSetSuccess = hierarchyEntity.Id.HasValue;
            }

            if (isSetSuccess)
            {
                if (form != null )
                {
                    form.Close();
                }
            }
            else
            {
                MessageBox.Show(@"Error on save");
            }
        }

        public static HierarchyEntity SetHierarchyParentByTreeView(TreeView hierarchyTreeView)
        {
            TreeNode selectedNode = null;
            if (hierarchyTreeView != null)
            {
                selectedNode = hierarchyTreeView.SelectedNode;
            }
            var hierarchyId = selectedNode == null ? null : (long?)selectedNode.Tag;

            var entity = new HierarchyEntity { Parent = hierarchyId };
            return entity;
        }
        public static HierarchyEntity SetHierarchyEntityByTreeView(TreeView hierarchyTreeView)
        {
            var selectedNode = hierarchyTreeView == null ? null : hierarchyTreeView.SelectedNode;

            long? hierarchyId = null;
            if (selectedNode != null)
            {
                hierarchyId = (long?)selectedNode.Tag;
            }
            List<HierarchyEntity> entityList = null;
            if (hierarchyId != null )
            {
                var businessLogic = new Hierarchy();
                entityList = businessLogic.Get(hierarchyId);
            }
            HierarchyEntity entity= null;
            if (entityList != null)
            {
                entity = entityList.FirstOrDefault();
            }
            
            return entity;
        }
        public static void DeleteHierarchy(TreeView hierarchyTreeView)
        {
            var entity = SetHierarchyEntityByTreeView(hierarchyTreeView);

            var businessLogic = new Hierarchy { EntityInstance = entity };
            var isDeleteSuccess = businessLogic.DeleteBranch();
            if (!isDeleteSuccess)
            {
                MessageBox.Show(@"Error on delete");
            }
        }

        public static void MoveHierarchy(Form form , HierarchyEntity source, TreeView hierarchyTreeView)
        {
            var target = SetHierarchyEntityByTreeView(hierarchyTreeView);
            var businessLogic = new Hierarchy { EntityInstance = source };
            var isSuccess = businessLogic.Move(source, target);
            if (isSuccess)
            {
                if (form != null)
                {
                    form.Close();
                }
            }
            else
            {
                MessageBox.Show(@"Error on move");
            }
        }
    }
}
