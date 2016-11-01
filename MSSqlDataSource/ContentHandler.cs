using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace MSSqlDataSource
{
    public class ContentHandler : DataSource
    {
        private Table<Content> DataSource { get; }
        public NullableContent SearchPattern { get; }
        public NullableContent Fields { private get; set; }

        public ContentHandler()
        {
            var appleStructure = DbContext;
            if (appleStructure != null)
            {
                DataSource = appleStructure.Contents;
            }
            SearchPattern = new NullableContent();
            Fields = new NullableContent();
        }

        public List<NullableContent> Get()
        {
            IQueryable<Content> records = DataSource;
            var pattern = SearchPattern;

            if (records != null
                && pattern != null )
            {
                var hierachyId = pattern.HierachyId;
                if (hierachyId.HasValue)
                {
                    records = records.Where(x=>x.Hierarchy == hierachyId.Value);
                }
                var id = pattern.Id;
                if (id.HasValue)
                {
                    records = records.Where(x => x.Id == id.Value);
                }
                var name = pattern.Name;
                if (name != null )
                {
                    records = records.Where(x => x.Name.Contains(name));
                }
                var content = pattern.ContentValue;
                if (content.HasValue)
                {
                    records = records.Where(x => x.ContentValue == content.Value);
                }
            }

            List<NullableContent> result = null;
            if (records != null)
            {
                foreach (var record in records)
                {
                    var resultRecord = new NullableContent(record);
                    if (result == null)
                    {
                        result = new List<NullableContent>();
                    }
                    result.Add(resultRecord);
                }
            }

            return result;
        }

        public NullableContent Set()
        {
            var fileds = Fields;

            Content record = null;
            if (fileds?.Id != null)
            {
                record = DataSource?.First(x => x.Id == fileds.Id.Value);
            }

            var perform = false;
            if (record != null)
            {
                if (fileds.HierachyId.HasValue)
                {
                    record.Hierarchy = fileds.HierachyId.Value;
                }
                record.ContentValue = fileds.ContentValue;
                record.Name = fileds.Name;

                perform = true;
            }

            var isSuccess = false;
            if (perform)
            {
                DataSource.Context?.SubmitChanges();
                isSuccess = true;
            }

            NullableContent result = null;
            if (isSuccess)
            {
                result = new NullableContent
                {
                    Id = record.Id,
                    ContentValue = record.ContentValue,
                    HierachyId = record.Hierarchy,
                    Name = record.Name
                };
            }

            return result;
        }

        public bool Delete()
        {
            var result = false;
            var fields = Fields;

            Content record = null;
            DataContext context = null;
            if (fields?.Id != null
                && DataSource!= null)
            {
                record = DataSource.First(x => x.Id == fields.Id.Value);
                context = DataSource.Context;
            }
            if (record != null && context != null )
            {
                DataSource.DeleteOnSubmit(record);
                context.SubmitChanges();
                result = true;
            }

            return result;
        }

        public NullableContent Add()
        {
            Content record = null;

            var dataSource = DataSource;
            var fields = Fields;
            if ( dataSource != null && fields != null)
            {
                record = new Content();
            }

            if (record != null )
            {
                record.ContentValue = fields.ContentValue;
                record.Name = fields.Name;
            }
            if ( record != null && fields.Id != null)
            {
                record.Id = fields.Id.Value;
            }

            if (fields?.HierachyId != null && record != null)
            {
                record.Hierarchy = fields.HierachyId.Value;
            }

            if (record != null )
            {
                dataSource.InsertOnSubmit(record);
                dataSource.Context?.SubmitChanges();
            }
            var result = new NullableContent(record);

            return result;
        }
    }
}
