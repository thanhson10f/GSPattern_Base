using System;

namespace GSP.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        GSPDataContext Get();
    }
}
