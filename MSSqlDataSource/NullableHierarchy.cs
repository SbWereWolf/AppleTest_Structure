namespace MSSqlDataSource
{
    public class NullableHierarchy
    {
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
    }
}
