using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Interfaces;
using WebApi.Entity.Entities;
using WebApi.Infrastructure.Context;

namespace WebApi.Infrastructure.Repositories
{
    public class AccountsRepository : RepositoryBase<User>, IAccountsRepository
    {
        public AccountsRepository(DataContext context): base(context)
        {

        }
    }
}
