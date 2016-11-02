using System.Collections.Generic;
using System.Linq;
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

        public static List<HierarchyEntity> GetAllHierarchies()
        {
            var result = HierarchyEntity.GetAllHierarchies();
            return result;
        }

        public List<HierarchyEntity> GetEntityChild()
        {
            HierarchyEntity entity = EntityInstance;
            List<HierarchyEntity> result = null;
            if (entity != null)
            {
                result = entity.GetChild();
            }
            return result;
        }

        public  bool Move(HierarchyEntity source, HierarchyEntity target)
        {
            var result = false;
            if (target != null && source != null)
            {
                var targetId = target.Id;
                var isSourceContainTarget = true;
                if (source.Id != targetId)
                {
                    var childList = GetEntityChild();
                    if (childList != null)
                    {
                        isSourceContainTarget = childList.Where(x=> x != null ).Any
                            // ReSharper disable SimplifyConditionalTernaryExpression
                            (x => x.Id.HasValue ? (x.Id.Value == targetId) : false);
                        // ReSharper restore SimplifyConditionalTernaryExpression
                    }
                    else
                    {
                        isSourceContainTarget = false;
                    }
                }
                if (!isSourceContainTarget)
                {
                    source.Parent = targetId;
                    source = Set();

                    if (source != null)
                    {
                        result = source.Id.HasValue;
                    }
                }
            }
            return result;
        }

        public bool DeleteBranch()
        {
            var result = false;
            if (EntityInstance != null)
            {
                if (EntityInstance.Id.HasValue)
                {
                    var hasDependency = EntityInstance.IsExistsDependency();

                    List<HierarchyEntity> entitesForDelete = null;
                    if (!hasDependency)
                    {
                        entitesForDelete = GetEntityChild() ?? new List<HierarchyEntity>();
                        entitesForDelete.Add(EntityInstance);
                    }

                    var isExistForDelete = entitesForDelete != null;
                    if (isExistForDelete && entitesForDelete.Count > 0)
                    {
                        result = true;
                        foreach (var hierarchyEntity in entitesForDelete)
                        {
                            var nextEntity = new Hierarchy { EntityInstance = hierarchyEntity };
                            result = result && nextEntity.Delete();
                        }
                    }
                }
            }
            return result;
        }
    }
}
