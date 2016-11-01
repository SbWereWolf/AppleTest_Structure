using MSSqlDataSource;

namespace DataAccess
{
    public class ContentRecord
    {
        public long? Id { get; set; }
        public long? HierachyId { get; set; }
        public string Name { get; set; }
        public float? ContentValue { get; set; }

        public ContentRecord()
        {
            Reset();
        }

        public ContentRecord(NullableContent nullable)
        {
            if (nullable != null)
            {
                Id = nullable.Id;
                ContentValue = nullable.ContentValue;
                HierachyId = nullable.HierachyId;
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
            HierachyId = null;
            Name = null;
            ContentValue = null;
        }

        public NullableContent RecordToNullable()
        {
            var fields = new NullableContent
            {
                Id = Id,
                ContentValue = ContentValue,
                HierachyId = HierachyId,
                Name = Name
            };
            return fields;
        }

    }
}
