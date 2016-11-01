namespace MSSqlDataSource
{
    public class NullableContent
    {
        public long? Id { get; set; }
        public long? HierachyId { get; set; }
        public string Name { get; set; }
        public float? ContentValue { get; set; }

        public NullableContent()
        {
            Reset();
        }

        public NullableContent(Content record)
        {
            Reset();
            if (record != null)
            {
                if (record.ContentValue.HasValue)
                {
                    ContentValue = record.ContentValue.Value;
                }
                HierachyId = record.Hierarchy;
                Id = record.Id;
                Name = record.Name;
            }
        }

        private void Reset()
        {
            Id = null;
            HierachyId = null;
            Name = null;
            ContentValue = null;
        }
    }
}
