namespace MSSqlDataSource
{
    public class DataSource 
    {
        protected StructureDatabaseDataContext DbContext { get; }

        protected DataSource()
        {
            DbContext = new StructureDatabaseDataContext();
        }
    }
}
