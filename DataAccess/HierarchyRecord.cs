using System.Collections.Generic;
using MSSqlDataSource;

namespace DataAccess
{
    public class HierarchyRecord
    {
        public long? Id { get; set; }
        public long? Parent { get; set; }
        public string Name { get; set; }

        public HierarchyRecord()
        {
            Reset();
        }

        public HierarchyRecord(NullableHierarchy nullable)
        {
            if (nullable != null)
            {
                Id = nullable.Id;
                Parent = nullable.Parent;
                Name = nullable.Name;
            }
            else
            {
                Reset();
            }
        }

        private void Reset()
        {
            Id = null;
            Parent = null;
            Name = null;
        }

        public NullableHierarchy RecordToNullable()
        {
            var fields = new NullableHierarchy
            {
                Id = Id,
                Parent = Parent,
                Name = Name
            };
            return fields;
        }

        public bool IsExistsDependency()
        {
            var record = RecordToNullable();
            var isExistDependency = true;

            if (record != null)
            {
                isExistDependency = record.IsExistsDependency();
            }

            return isExistDependency;
        }

        private static List<HierarchyRecord> NulableListToRecordList(List<NullableHierarchy> recordList)
        {
            List<HierarchyRecord> child = null;
            if (recordList != null)
            {
                foreach (var record in recordList)
                {
                    var entity = new HierarchyRecord(record);
                    if (child == null)
                    {
                        child = new List<HierarchyRecord>();
                    }
                    child.Add(entity);
                }
            }
            return child;
        }


        public static List<HierarchyRecord> GetAllHierarchies()
        {
            var recordList = NullableHierarchy.GetAllHierarchies();

            var entities = NulableListToRecordList(recordList);
            return entities;
        }

        public List<HierarchyRecord> GetChild()
        {

            var nullableHierarchy = RecordToNullable();

            List<NullableHierarchy> recordList = null;
            if (nullableHierarchy != null)
            {
                recordList = nullableHierarchy.GetChild();
            }
            var child = NulableListToRecordList(recordList);

            return child;
        }
    }
}
