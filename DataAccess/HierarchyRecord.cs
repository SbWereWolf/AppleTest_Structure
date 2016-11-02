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

    }
}
