using System.Collections.Generic;
using MSSqlDataSource;

namespace DataAccess
{
    public class Content
    {
        public ContentRecord Record
        {
            get { return _record; }
        }

        public ContentRecord Pattern
        {
            get { return _pattern; }
        }

        private readonly ContentHandler _handler;
        private readonly ContentRecord _pattern;
        private readonly ContentRecord _record;

        public Content()
        {
            _record = new ContentRecord();
            _pattern = new ContentRecord();
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
