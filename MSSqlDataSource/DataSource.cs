namespace MSSqlDataSource
{
    public class DataSource 
    {
        private readonly StructureDatabaseDataContext _dbContext;

        protected StructureDatabaseDataContext DbContext
        {
            get { return _dbContext; }
        }

        protected DataSource()
        {
            _dbContext = new StructureDatabaseDataContext();
        }
    }
}
