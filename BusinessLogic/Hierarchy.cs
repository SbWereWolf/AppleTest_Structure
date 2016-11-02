using System.Collections.Generic;
using DataAccess;

namespace BusinessLogic
{
    public class Hierarchy
    {
        private DataAccess.Hierarchy Handler
        {
            get { return _handler; }
        }

        public HierarchyEntity EntityInstance;
        private readonly DataAccess.Hierarchy _handler;

        public Hierarchy()
        {
            _handler = new DataAccess.Hierarchy();
            EntityInstance = new HierarchyEntity();
        }

        public List<HierarchyEntity> Get(long? hierarchyId = null , long? parent = null, string name = null)
        {
            List<HierarchyEntity> result = null;
            var handler = Handler;
            if (handler != null )
            {
             if (handler.Pattern != null)
            {
                handler.Pattern.Parent = parent;
                handler.Pattern.Id = hierarchyId;
                handler.Pattern.Name = name;
            }               
            }

            List<HierarchyRecord> records = null;
            if ( handler!= null )
            {
                records = handler.Get();
            }
            if (records!= null )
            {
                foreach (var record in records)
                {
                    if (record!= null)
                    {
                        var resultRecord = new HierarchyEntity(record);
                        if (result == null )
                        {
                            result = new List<HierarchyEntity>();
                        }
                        result.Add(resultRecord);
                    }
                }
            }

            return result;
        }

        public HierarchyEntity Set()
        {
            HierarchyEntity result = null ;
            HierarchyRecord saveResult = null ;
            var handler = GetHandler();
            if (handler != null)
            {
                saveResult = handler.Save();
            }
            if (saveResult != null )
            {
                result = new HierarchyEntity(saveResult);
            }

            return result;
        }

        private DataAccess.Hierarchy GetHandler()
        {
            DataAccess.Hierarchy handler = null;
            var record = EntityInstance;
            if (record != null)
            {
                handler = new DataAccess.Hierarchy
                {
                    Record =
                    {
                        Parent = record.Parent,
                        Id = record.Id,
                        Name = record.Name
                    }
                };
                
            }
            return handler;
        }

        public bool Delete()
        {
            var  result = false;
            var handler = GetHandler();
            if (handler != null)
            {
                result = handler.Delete();
            }

            return result;
        }
    }
}
