using System.Collections.Generic;
using MSSqlDataSource;

namespace DataAccess
{
    public class Hierarchy
    {
        public HierarchyRecord Record { get; }
        public HierarchyRecord Pattern { get; }
        private readonly HierarchyHandler _handler;

        public Hierarchy()
        {
            Record = new HierarchyRecord();
            Pattern = new HierarchyRecord();
            _handler = new HierarchyHandler();
        }

        
        public List<HierarchyRecord> Get()
        {
            List<HierarchyRecord> result = null;

            var handler = _handler;
            List<NullableHierarchy> records = null;
            if (handler!= null )
            {
                if (handler.SearchPattern != null && Pattern != null)
                {
                    handler.SearchPattern.Parent = Pattern.Parent;
                    handler.SearchPattern.Id = Pattern.Id;
                    handler.SearchPattern.Name = Pattern.Name;
                }

                records = handler.Get();
            }
            if (records!= null)
            {
                foreach (var record in records)
                {
                    if (record!=null)
                    {
                        var resultRecord = new HierarchyRecord
                        {
                            Parent = record.Parent,
                            Id = record.Id,
                            Name = record.Name
                        };
                        if (result == null)
                        {
                            result = new List<HierarchyRecord>();
                        }
                        result.Add(resultRecord);
                    }
                }
            }

            return result;
        }

        public bool Delete()
        {
            var result = false;
            var handler = _handler;
            var record = Record;

            if (record != null
                && handler != null)
            {
                handler.Fields = record.RecordToNullable();
                result = handler.Delete();
            }

            return result;
        }

        public HierarchyRecord Save()
        {
            
            var handler = _handler;
            var record = Record;

            HierarchyRecord result = null;
            if (record != null 
                && handler != null )
            {
                handler.Fields = record.RecordToNullable();
                
                var isNew = record.Id == null;
                var saveResult = isNew ? handler.Add() : handler.Set();
                
                if (saveResult != null )
                {
                    result = new HierarchyRecord(saveResult);
                }
            }

            return result;
        }


    }
}
