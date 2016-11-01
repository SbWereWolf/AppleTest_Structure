using DataAccess;

namespace BusinessLogic
{
    public class ContentEntity
    {
        public long? Id { get; set; }
        public long? HierachyId { get; set; }
        public string Name { get; set; }
        public float? ContentValue { get; set; }

        public ContentEntity()
        {
            Reset();
        }

        public ContentEntity(ContentRecord saveResult)
        {
            Reset();
            if (saveResult != null)
            {
                Id = saveResult.Id;
                ContentValue = saveResult.ContentValue;
                HierachyId = saveResult.HierachyId;
                Name = saveResult.Name;
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
