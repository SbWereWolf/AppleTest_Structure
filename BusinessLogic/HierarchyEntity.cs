using DataAccess;

namespace BusinessLogic
{
    public class HierarchyEntity
    {
        public long? Id { get; set; }
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

    }
}
