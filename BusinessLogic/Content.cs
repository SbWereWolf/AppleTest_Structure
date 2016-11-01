using System.Collections.Generic;
using DataAccess;

namespace BusinessLogic
{
    public class Content
    {
        private DataAccess.Content Handler
        {
            get { return _handler; }
        }

        public ContentEntity EntityInstance;
        private readonly DataAccess.Content _handler;

        public Content()
        {
            _handler = new DataAccess.Content();
            EntityInstance = new ContentEntity();
        }

        public List<ContentEntity> Get(long? contentId = null , long? hierachyId = null, string name = null, float? content = null)
        {
            List<ContentEntity> result = null;
            var handler = Handler;
            if (handler != null)
            {
             if (handler.Pattern != null)
            {
                handler.Pattern.ContentValue = content;
                handler.Pattern.HierachyId = hierachyId;
                handler.Pattern.Id = contentId;
                handler.Pattern.Name = name;
            }               
            }

            List<ContentRecord> records = null;
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
                        var resultRecord = new ContentEntity
                        {
                            ContentValue = record.ContentValue,
                            HierachyId = record.HierachyId,
                            Id = record.Id,
                            Name = record.Name
                        };
                        if (result == null )
                        {
                            result = new List<ContentEntity>();
                        }
                        result.Add(resultRecord);
                    }
                }
            }

            return result;
        }

        public ContentEntity Set()
        {
            ContentEntity result = null ;
            ContentRecord saveResult = null ;
            var handler = GetHandler();
            if (handler != null)
            {
                saveResult = handler.Save();
            }
            if (saveResult != null )
            {
                result = new ContentEntity(saveResult);
            }

            return result;
        }

        private DataAccess.Content GetHandler()
        {
            DataAccess.Content handler = null;
            var record = EntityInstance;
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
