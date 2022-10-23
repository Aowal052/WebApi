using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entity.Entities;

namespace WebApi.Application.Interfaces
{
    public interface IAccountsRepository: IAsyncRepository<User>
    {
    }
}
