using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace MSSqlDataSource
{
    public class HierarchyHandler : DataSource
    {
        private Table<Hierarchy> DataSource { get; }
        public NullableHierarchy SearchPattern { get; }
        public NullableHierarchy Fields { private get; set; }

        public HierarchyHandler()
        {
            var appleStructure = DbContext;
            if (appleStructure != null)
            {
                DataSource = appleStructure.Hierarchies;
            }
            SearchPattern = new NullableHierarchy();
            Fields = new NullableHierarchy();
        }

        public List<NullableHierarchy> Get()
        {
            IQueryable<Hierarchy> records = DataSource;
            var pattern = SearchPattern;

            if (records != null
                && pattern != null )
            {
                var parent = pattern.Parent;
                if (parent.HasValue)
                {
                    records = records.Where(x=>x.Parent == parent.Value);
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
            }

            List<NullableHierarchy> result = null;
            if (records != null)
            {
                foreach (var record in records)
                {
                    var resultRecord = new NullableHierarchy(record);
                    if (result == null)
                    {
                        result = new List<NullableHierarchy>();
                    }
                    result.Add(resultRecord);
                }
            }

            return result;
        }

        public NullableHierarchy Set()
        {
            var fileds = Fields;

            Hierarchy record = null;
            if (fileds?.Id != null)
            {
                record = DataSource?.First(x => x.Id == fileds.Id.Value);
            }

            var perform = false;
            if (record != null)
            {
                if (fileds.Parent.HasValue)
                {
                    record.Parent = fileds.Parent.Value;
                }
                record.Name = fileds.Name;

                perform = true;
            }

            var isSuccess = false;
            if (perform)
            {
                DataSource.Context?.SubmitChanges();
                isSuccess = true;
            }

            NullableHierarchy result = null;
            if (isSuccess)
            {
                result = new NullableHierarchy
                {
                    Id = record.Id,
                    Parent = record.Parent,
                    Name = record.Name
                };
            }

            return result;
        }

        public bool Delete()
        {
            var result = false;
            var fields = Fields;

            Hierarchy record = null;
            DataContext context = null;
            if (fields?.Id != null
                && DataSource!= null)
            {
                record = DataSource.FirstOrDefault(x => x.Id == fields.Id.Value);
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

        public NullableHierarchy Add()
        {
            Hierarchy record = null;

            var dataSource = DataSource;
            var fields = Fields;
            if ( dataSource != null && fields != null)
            {
                record = new Hierarchy();
            }

            if (record != null )
            {
                record.Name = fields.Name;
            }
            if ( record != null && fields.Id != null)
            {
                record.Id = fields.Id.Value;
            }

            if (fields?.Parent != null && record != null)
            {
                record.Parent = fields.Parent.Value;
            }

            if (record != null )
            {
                dataSource.InsertOnSubmit(record);
                dataSource.Context?.SubmitChanges();
            }
            var result = new NullableHierarchy(record);

            return result;
        }
    }
}
