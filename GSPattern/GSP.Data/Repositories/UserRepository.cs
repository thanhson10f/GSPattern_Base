﻿using GSP.Data.Infrastructure;
using GSP.Model.Entities;

namespace GSP.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IUserRepository : IRepository<User>
    {
    }
}
