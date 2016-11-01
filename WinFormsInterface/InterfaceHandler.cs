using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BusinessLogic;

namespace WinFormsInterface
{
    internal static class InterfaceHandler
    {
        //public static void RefreshList(DataGridView recordsDataGridView)
        //{
        //    var businessLogic = new Content();
        //    var records = businessLogic.Get();

        //    if (recordsDataGridView != null)
        //    {
        //        recordsDataGridView.DataSource = records;
        //    }
        //}

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
                form?.Close();
            }
            else
            {
                MessageBox.Show(@"Error on save");
            }
        }

        public static ContentEntity GetGridContentRecord( DataGridView dataGridView)
        {
            var selectedCellCount = dataGridView?.SelectedCells.Count;

            DataGridViewCell cellId = null;
            DataGridViewCell cellHierachyId = null;
            DataGridViewCell cellName = null;
            DataGridViewCell cellContentValue = null;
            if (selectedCellCount > 0)
            {
                var cell = dataGridView.SelectedCells[0];
                var selectedRow = cell?.OwningRow;
                if (selectedRow != null)
                {
                    cellId = selectedRow.Cells["Id"];
                    cellHierachyId = selectedRow.Cells["HierachyId"];
                    cellName = selectedRow.Cells["Name"];
                    cellContentValue = selectedRow.Cells["ContentValue"];
                }
            }
            var contentIdString = string.Empty;
            if (cellId?.Value != null)
            {
                contentIdString = cellId.Value.ToString();
            }
            var hierachyIdString = string.Empty;
            if (cellHierachyId?.Value != null)
            {
                hierachyIdString = cellHierachyId.Value.ToString();
            }
            var name = string.Empty;
            if (cellName?.Value != null)
            {
                name = cellName.Value.ToString();
            }
            var contentValueString = string.Empty;
            if (cellContentValue?.Value != null)
            {
                contentValueString = cellContentValue.Value.ToString();
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
            List<HierarchyEntity> records = null;
            var connectionString = GetInterfaceConnectionString();
            if (!string.IsNullOrEmpty(connectionString) )
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    const string cId = "ID";
                    const string cParent = "PARENT";
                    const string cName = "NAME";
                    var getHierarchyStructure = connection.CreateCommand();
                    getHierarchyStructure.CommandText =
                        $@"
WITH HierarchyCTE (Id, Name, Parent, LEVEL)
AS (SELECT HRoot.Id, HRoot.Name, HRoot.Parent, 0
FROM Hierarchy HRoot
WHERE HRoot.Parent IS NULL
UNION ALL
SELECT HChild.Id, HChild.Name, HChild.Parent, CTE.LEVEL + 1 
FROM Hierarchy HChild
INNER JOIN HierarchyCTE CTE ON HChild.Parent = CTE.Id
WHERE HChild.Parent IS NOT NULL)
SELECT HierarchyCTE.Id AS {cId}, HierarchyCTE.Parent AS {cParent} , HierarchyCTE.Name AS {cName} 
FROM HierarchyCTE
ORDER BY HierarchyCTE.LEVEL
";

                    connection.Open();

                    var reader = getHierarchyStructure.ExecuteReader();
                    while (reader.Read())
                    {
                        var entity = new HierarchyEntity
                        {
                            Id = (long?) (reader[cId] == DBNull.Value ? null : reader[cId] ),
                            Name = (string) reader[cName],
                            Parent = (long?) (reader[cParent] == DBNull.Value ? null : reader[cParent] )
                        };
                        
                        if (records == null)
                        {
                            records = new List<HierarchyEntity>();
                        }
                        records.Add(entity);
                    }
                }
            }

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
                            Name = entity.Id?.ToString(CultureInfo.InvariantCulture) ?? string.Empty
                        };

                        var parent = entity.Parent;
                        var parentNode = (from treeNode in nodesCache let tag = (long?)treeNode?.Tag where tag == parent select treeNode).FirstOrDefault();
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
            var selectedNode = hierarchyTreeView?.SelectedNode;
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
            var selectedNode = hierarchyTreeView?.SelectedNode;
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
                form?.Close();
            }
            else
            {
                MessageBox.Show(@"Error on save");
            }
        }

        public static HierarchyEntity SetHierarchyParentByTreeView(TreeView hierarchyTreeView)
        {
            var selectedNode = hierarchyTreeView?.SelectedNode;
            var hierarchyId = (long?)selectedNode?.Tag;

            var entity = new HierarchyEntity { Parent = hierarchyId };
            return entity;
        }
        public static HierarchyEntity SetHierarchyEntityByTreeView(TreeView hierarchyTreeView)
        {
            var selectedNode = hierarchyTreeView?.SelectedNode;

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
        public static bool DeleteHierarchy(TreeView hierarchyTreeView)
        {
            var result = false;

            var entity = SetHierarchyEntityByTreeView(hierarchyTreeView);

            var connectionString = GetInterfaceConnectionString();

            var isExistDependency = true;
            if (entity?.Id != null)
            {
                var entityIdObject = (object)entity.Id.Value.ToString(CultureInfo.InvariantCulture);
                const string cNode = "@NODE";

                if (!string.IsNullOrEmpty(connectionString) && entity.Id != null)
                {
                    using (var dependencyConnection = new SqlConnection(connectionString))
                    {
                        var getDependencyCommand = dependencyConnection.CreateCommand();
                        getDependencyCommand.CommandText =
                            $@"
WITH HierarchyCTE (Id, Name, Parent, LEVEL)
AS (SELECT HRoot.Id, HRoot.Name, HRoot.Parent, 1
FROM Hierarchy HRoot
WHERE HRoot.Id = {cNode}
UNION ALL
SELECT HChild.Id, HChild.Name, HChild.Parent, CTE.LEVEL + 1 
FROM Hierarchy HChild
INNER JOIN HierarchyCTE CTE ON HChild.Parent = CTE.Id
WHERE HChild.Parent IS NOT NULL)
SELECT 'yes' AS isExists WHERE  EXISTS ( SELECT null FROM HierarchyCTE
LEFT JOIN [Content] C ON HierarchyCTE.Id = C.Hierarchy
WHERE C.Id IS NOT NULL  )
";

                        var nodeId = new SqlParameter(cNode, entityIdObject);
                        getDependencyCommand.Parameters.Add(nodeId);

                        dependencyConnection.Open();

                        var rowAffected = getDependencyCommand.ExecuteScalar();
                        isExistDependency = rowAffected != null;
                    }
                }

                List<long?> listForDelete = null;
                if (isExistDependency)
                {
                    MessageBox.Show(@"Error on delete");
                }
                else
                {
                    listForDelete = GetChild(connectionString, entity) ?? new List<long?>();
                    listForDelete.Add(entity.Id.Value);
                }

                var isExistForDelete = listForDelete != null && listForDelete.Count > 0;
                if (isExistForDelete)
                {
                    foreach (var id in listForDelete)
                    {
                        var nextEntity = new Hierarchy { EntityInstance = { Id = id } };
                        result = nextEntity.Delete();
                    }
                }
            }
            return result;
        }

        private static string GetInterfaceConnectionString()
        {
            var connectionString = string.Empty;
            if (ConfigurationManager.ConnectionStrings != null)
            {
                var connectionStringSettings =
                    ConfigurationManager.ConnectionStrings["AppleStructureConnectionString"];
                if (connectionStringSettings !=
                    null)
                {
                    connectionString = connectionStringSettings.ConnectionString;
                }
            }
            return connectionString;
        }

        private static List<long?> GetChild(string connectionString, HierarchyEntity entity)
        {
            List<long?> child = null;
            if (connectionString != null && entity?.Id != null)
            {
                using (var performDeleteConnection = new SqlConnection(connectionString))
                {
                    const string cNode = "@NODE";
                    const string cId = "ID";

                    var entityIdObject = (object) entity.Id.Value.ToString(CultureInfo.InvariantCulture);

                    var getListCommand = performDeleteConnection.CreateCommand();
                    getListCommand.CommandText =
                        $@"
WITH HierarchyCTE (Id, Name, Parent, LEVEL)
AS (SELECT HRoot.Id, HRoot.Name, HRoot.Parent, 1
FROM Hierarchy HRoot
WHERE HRoot.Id = {cNode}
UNION ALL
SELECT HChild.Id, HChild.Name, HChild.Parent, CTE.LEVEL + 1 
FROM Hierarchy HChild
INNER JOIN HierarchyCTE CTE ON HChild.Parent = CTE.Id
WHERE HChild.Parent IS NOT NULL)
SELECT DISTINCT HierarchyCTE.Id AS {cId}, HierarchyCTE.LEVEL
FROM HierarchyCTE
LEFT JOIN [Content] C ON HierarchyCTE.Id = C.Hierarchy
EXCEPT
SELECT HRoot.Id, 1
FROM Hierarchy HRoot
WHERE HRoot.Id = {cNode}
ORDER BY LEVEL DESC
";

                    var nodeId = new SqlParameter(cNode, entityIdObject);
                    getListCommand.Parameters.Add(nodeId);

                    performDeleteConnection.Open();

                    var reader = getListCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var recordId = (long?) reader[cId];
                        if (child == null)
                        {
                            child = new List<long?>();
                        }
                        child.Add(recordId);
                    }
                }
            }

            return child;
        }
        public static void MoveHierarchy(Form form , HierarchyEntity source, TreeView hierarchyTreeView)
        {
            var target = SetHierarchyEntityByTreeView(hierarchyTreeView);
            if (target != null && source != null)
            {
                var targetId = target.Id;
                bool isContainEntity = true;
                if (source.Id != targetId)
                {
                    var connectionString = GetInterfaceConnectionString();
                    var childList = GetChild(connectionString, source);
                    if (childList != null)
                    {
                        isContainEntity = childList.Any
                            // ReSharper disable SimplifyConditionalTernaryExpression
                            (x => x.HasValue ? x.Value == targetId : false);
                        // ReSharper restore SimplifyConditionalTernaryExpression
                    }
                    else
                    {
                        isContainEntity = false;
                    }
                }
                if (!isContainEntity)
                {
                    source.Parent = targetId;
                    SaveHierarchyEntity(form, source, source.Name);
                }
                else
                {
                    MessageBox.Show(@"Error on move");
                }
            }
        }
    }
}
