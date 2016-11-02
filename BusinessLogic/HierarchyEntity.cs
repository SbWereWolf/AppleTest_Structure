using System.Collections.Generic;
using DataAccess;

namespace BusinessLogic
{
    public class HierarchyEntity
    {
        public long? Id { get; private set; }
        public long? Parent { get; set; }
        public string Name { get; set; }

        public HierarchyEntity()
        {
            Reset();
        }

        public HierarchyEntity(HierarchyRecord saveResult)
        {
            Reset();
            if (saveResult != null)
            {
                Id = saveResult.Id;
                Parent = saveResult.Parent;
                Name = saveResult.Name;
            }
        }

        private void Reset()
        {
            Id = null;
            Parent = null;
            Name = null;
        }

        public static List<HierarchyEntity> GetAllHierarchies()
        {
            var recordList = HierarchyRecord.GetAllHierarchies();

            var entities = RecordListToEntitiesList(recordList);
            return entities;
        }

        public List<HierarchyEntity> GetChild()
        {
            var hierarchyRecord = EntityToHierarchyRecord();

            List<HierarchyRecord> recordList = null;
            if (hierarchyRecord != null )
            {
                recordList = hierarchyRecord.GetChild();
            }
            var child = RecordListToEntitiesList(recordList);

            return child;
        }

        private static List<HierarchyEntity> RecordListToEntitiesList(List<HierarchyRecord> recordList)
        {
            List<HierarchyEntity> child = null;
            if (recordList != null)
            {
                foreach (var record in recordList)
                {
                    var entity = new HierarchyEntity(record);
                    if (child == null)
                    {
                        child = new List<HierarchyEntity>();
                    }
                    child.Add(entity);
                }
            }
            return child;
        }

        public bool IsExistsDependency()
        {
            var record = EntityToHierarchyRecord();
            var isExistDependency = true;

            if (record != null)
            {
                isExistDependency = record.IsExistsDependency();
            }

            return isExistDependency;
        }

        private HierarchyRecord EntityToHierarchyRecord()
        {
            var fields = new HierarchyRecord
            {
                Id = Id,
                Parent = Parent,
                Name = Name
            };
            return fields;
        }
    }
}
