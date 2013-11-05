
namespace GSP.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private GSPDataContext dataContext;
        public GSPDataContext Get()
        {
            return dataContext ?? (dataContext = new GSPDataContext());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
