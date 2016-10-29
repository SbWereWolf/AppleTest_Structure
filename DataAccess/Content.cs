using System.Collections.Generic;
using MSSqlDataSource;

namespace DataAccess
{
    public class Content
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

        public ContentRecord Record { get; set; }
        public ContentRecord Pattern { get; set; }
        private readonly ContentHandler _handler;

        public Content()
        {
            Record = new ContentRecord();
            Pattern = new ContentRecord();
            _handler = new ContentHandler();
        }

        
        public List<ContentRecord> Get()
        {
            List<ContentRecord> result = null;

            var handler = _handler;
            List<NullableContent> records = null;
            if (handler!= null )
            {
                if (handler.SearchPattern != null && Pattern != null)
                {
                    handler.SearchPattern.HierachyId = Pattern.HierachyId;
                    handler.SearchPattern.Id = Pattern.Id;
                    handler.SearchPattern.Name = Pattern.Name;
                    handler.SearchPattern.ContentValue = Pattern.ContentValue;
                }

                records = handler.Get();
            }
            if (records!= null)
            {
                foreach (var record in records)
                {
                    if (record!=null)
                    {
                        var resultRecord = new ContentRecord
                        {
                            ContentValue = record.ContentValue,
                            HierachyId = record.HierachyId,
                            Id = record.Id,
                            Name = record.Name
                        };
                        if (result == null)
                        {
                            result = new List<ContentRecord>();
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

        public ContentRecord Save()
        {
            
            var handler = _handler;
            var record = Record;

            ContentRecord result = null;
            if (record != null 
                && handler != null )
            {
                handler.Fields = record.RecordToNullable();
                
                var isNew = record.Id == null;
                var saveResult = isNew ? handler.Add() : handler.Set();
                
                if (saveResult != null )
                {
                    result = new ContentRecord(saveResult);
                }
            }

            return result;
        }


    }
}
