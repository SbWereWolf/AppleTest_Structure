using System.Collections.Generic;

namespace BusinessLogic
{
    public class Content
    {
        private DataAccess.Content Handler { get; }

        public Record ContentRecord;
        public Content()
        {
            Handler = new DataAccess.Content();
            ContentRecord = new Record();
        }

        public class Record 
        {
            public long? Id { get; set; }
            public long? HierachyId { get; set; }
            public string Name { get; set; }
            public float? ContentValue { get; set; }

            public Record()
            {
                Reset();
            }

            public Record(DataAccess.Content.ContentRecord saveResult)
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

        public List<Record> Get(long? contentId = null , long? hierachyId = null, string name = null, float? content = null)
        {
            List<Record> result = null;
            var handler = Handler;
            if (handler?.Pattern != null)
            {
                handler.Pattern.ContentValue = content;
                handler.Pattern.HierachyId = hierachyId;
                handler.Pattern.Id = contentId;
                handler.Pattern.Name = name;
            }
            List<DataAccess.Content.ContentRecord> records = null;
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
                        var resultRecord = new Record
                        {
                            ContentValue = record.ContentValue,
                            HierachyId = record.HierachyId,
                            Id = record.Id,
                            Name = record.Name
                        };
                        if (result == null )
                        {
                            result = new List<Record>();
                        }
                        result.Add(resultRecord);
                    }
                }
            }

            return result;
        }

        public Record Set()
        {
            Record result = null ;
            DataAccess.Content.ContentRecord saveResult = null ;
            var handler = GetHandler();
            if (handler != null)
            {
                saveResult = handler.Save();
            }
            if (saveResult != null )
            {
                result = new Record(saveResult);
            }

            return result;
        }

        private DataAccess.Content GetHandler()
        {
            DataAccess.Content handler = null;
            var record = ContentRecord;
            if (record != null)
            {
                handler = new DataAccess.Content
                {
                    Record =
                    {
                        HierachyId = record.HierachyId,
                        ContentValue = record.ContentValue,
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
