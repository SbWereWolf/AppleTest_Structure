using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;

namespace MSSqlDataSource
{
    public class NullableHierarchy
    {
        const string IdColumn = "ID";
        const string ParentColumn = "PARENT";
        const string NameColumn = "NAME";
        const string NodeParameterName = "@NODE";

        public long? Id { get; set; }
        public long? Parent { get; set; }
        public string Name { get; set; }

        public NullableHierarchy()
        {
            Reset();
        }

        public NullableHierarchy(Hierarchy record)
        {
            Reset();
            if (record != null)
            {
                if (record.Parent.HasValue)
                {
                    Parent = record.Parent.Value;
                }
                Id = record.Id;
                Name = record.Name;
            }
        }

        private void Reset()
        {
            Id = null;
            Parent = null;
            Name = null;
        }

        private NullableHierarchy(SqlDataReader reader)
        {
            Reset();
            if (reader != null)
            {
                Id = (long?)(reader[IdColumn] == DBNull.Value ? null : reader[IdColumn]);
                Name = (string)reader[NameColumn];
                Parent = (long?)(reader[ParentColumn] == DBNull.Value ? null : reader[ParentColumn]);
            }

        }

        private static string GetConnectionString()
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

        public bool IsExistsDependency()
        {
            var isExistDependency = true;

            var connectionString = GetConnectionString();
            if (!string.IsNullOrEmpty(connectionString) && Id != null)
            {
                using (var dependencyConnection = new SqlConnection(connectionString))
                {
                    var getDependencyCommand = dependencyConnection.CreateCommand();
                    getDependencyCommand.CommandText = string.Format(
                        @"
WITH HierarchyCTE (Id, Name, Parent, LEVEL)
AS (SELECT HRoot.Id, HRoot.Name, HRoot.Parent, 1
FROM Hierarchy HRoot
WHERE HRoot.Id = {0}
UNION ALL
SELECT HChild.Id, HChild.Name, HChild.Parent, CTE.LEVEL + 1 
FROM Hierarchy HChild
INNER JOIN HierarchyCTE CTE ON HChild.Parent = CTE.Id
WHERE HChild.Parent IS NOT NULL)
SELECT 'yes' AS isExists WHERE  EXISTS ( SELECT null FROM HierarchyCTE
LEFT JOIN [Content] C ON HierarchyCTE.Id = C.Hierarchy
WHERE C.Id IS NOT NULL  )
", NodeParameterName);

                    var entityIdObject = (object)Id.Value.ToString(CultureInfo.InvariantCulture);
                    var nodeId = new SqlParameter(NodeParameterName, entityIdObject);
                    getDependencyCommand.Parameters.Add(nodeId);

                    dependencyConnection.Open();

                    var rowAffected = getDependencyCommand.ExecuteScalar();
                    isExistDependency = rowAffected != null;
                }
            }

            return isExistDependency;
        }
        public static List<NullableHierarchy> GetAllHierarchies()
        {
            List<NullableHierarchy> records = null;
            var connectionString = GetConnectionString();
            if (!string.IsNullOrEmpty(connectionString))
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var getHierarchyStructure = connection.CreateCommand();
                    getHierarchyStructure.CommandText = string.Format(@"
WITH HierarchyCTE (Id, Name, Parent, LEVEL)
AS (SELECT HRoot.Id, HRoot.Name, HRoot.Parent, 0
FROM Hierarchy HRoot
WHERE HRoot.Parent IS NULL
UNION ALL
SELECT HChild.Id, HChild.Name, HChild.Parent, CTE.LEVEL + 1 
FROM Hierarchy HChild
INNER JOIN HierarchyCTE CTE ON HChild.Parent = CTE.Id
WHERE HChild.Parent IS NOT NULL)
SELECT HierarchyCTE.Id AS {0}, HierarchyCTE.Parent AS {1} , HierarchyCTE.Name AS {2} 
FROM HierarchyCTE
ORDER BY HierarchyCTE.LEVEL
", IdColumn, ParentColumn, NameColumn);

                    connection.Open();

                    var reader = getHierarchyStructure.ExecuteReader();
                    while (reader.Read())
                    {
                        var entity = new NullableHierarchy
                        {
                            Id = (long?)(reader[IdColumn] == DBNull.Value ? null : reader[IdColumn]),
                            Name = (string)reader[NameColumn],
                            Parent = (long?)(reader[ParentColumn] == DBNull.Value ? null : reader[ParentColumn])
                        };

                        if (records == null)
                        {
                            records = new List<NullableHierarchy>();
                        }
                        records.Add(entity);
                    }
                }
            }
            return records;
        }
        public List<NullableHierarchy> GetChild()
        {
            List<NullableHierarchy> child = null;
            var connectionString = GetConnectionString();
            if (connectionString != null && Id.HasValue)
            {
                using (var getChildConnection = new SqlConnection(connectionString))
                {
                    var entityIdObject = (object)Id.Value.ToString(CultureInfo.InvariantCulture);

                    var getChildCommand = getChildConnection.CreateCommand();
                    getChildCommand.CommandText = string.Format(@"
WITH HierarchyCTE (Id, Name, Parent, LEVEL)
AS (SELECT HRoot.Id, HRoot.Name, HRoot.Parent, 1
FROM Hierarchy HRoot
WHERE HRoot.Id = {0}
UNION ALL
SELECT HChild.Id, HChild.Name, HChild.Parent, CTE.LEVEL + 1 
FROM Hierarchy HChild
INNER JOIN HierarchyCTE CTE ON HChild.Parent = CTE.Id
WHERE HChild.Parent IS NOT NULL)
SELECT DISTINCT HierarchyCTE.Id AS {1} , HierarchyCTE.Name AS {2}, HierarchyCTE.Parent AS {3}, LEVEL 
FROM HierarchyCTE
LEFT JOIN [Content] C ON HierarchyCTE.Id = C.Hierarchy
EXCEPT
SELECT HRoot.Id, HRoot.Name, HRoot.Parent, 1
FROM Hierarchy HRoot
WHERE HRoot.Id = {0}
ORDER BY LEVEL DESC
", NodeParameterName, IdColumn, NameColumn, ParentColumn);

                    var nodeId = new SqlParameter(NodeParameterName, entityIdObject);
                    getChildCommand.Parameters.Add(nodeId);

                    getChildConnection.Open();

                    var reader = getChildCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var entity = new NullableHierarchy(reader);
                        if (child == null)
                        {
                            child = new List<NullableHierarchy>();
                        }
                        child.Add(entity);
                    }
                }
            }

            return child;
        }
    }
}
