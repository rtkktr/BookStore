using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Contracts
{
    public interface IAuthorRepository<Tkey, TExist> : IBaseRepository<Author?,Tkey,TExist>
    {

    }
}
